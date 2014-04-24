using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChef.Business.Models;
using MasterChefDb.Models;
using System.Reflection;
using System.Collections;

namespace MasterChef.DAL.Concrete
{
    public class DbMapper
    {
        // TDest - TSource
        private List<Tuple<Type, Type>> types = new List<Tuple<Type, Type>>();

        // BaseType-ChildType: value
        private Dictionary<Tuple<Type, Type>, object> conflicts = new Dictionary<Tuple<Type, Type>, object>();

        #region public
        public void Map<TSource, TResult>()
        {
            types.Add(Tuple.Create(typeof(TResult), typeof(TSource)));
        }

        public void Conflict<TBase, TChild>()
        {
            conflicts.Add(Tuple.Create(typeof(TBase), typeof(TChild)), null);
        }



        #endregion

        public TResult Get<TResult, TSource>(TSource source) where TResult : new()
        {
            return (TResult)Get(typeof(TResult), typeof(TSource), source);
        }

        private object Get(Type TResult, Type TSource, object source)
        {
            if (!(IsMapped(TSource) && IsMapped(TResult)))
                throw new InvalidOperationException();

            if (source == null)
                return null;

            var result = TResult.GetConstructor(new Type[] { }).Invoke(null);

            SetConflicting(TSource, result);

            foreach (var toProp in TResult.GetProperties())
            {
                var fromProp = TSource.GetProperty(toProp.Name);

                if (fromProp == null) continue;

                object value;
                KeyValuePair<Tuple<Type, Type>, object> conflict;
                var toType = toProp.PropertyType;
                var fromType = fromProp.PropertyType;

                if (CheckConflict(TSource, fromType, out conflict))
                    value = conflict.Value;

                else if (IsClass(toType))
                    value = Get(toType, fromType, fromProp.GetValue(source));

                else if (IsCollection(toType) && fromProp.GetValue(source) != null)
                    value = CreateCollection(toType, fromProp, source);

                else
                    value = fromProp.GetValue(source);

                toProp.SetValue(result, value);
            }

            return result;
        }

        private object CreateCollection(Type toType, PropertyInfo sourceProp, object source)
        {
            var toItemType = toType.GenericTypeArguments[0];
            var fromItemType = sourceProp.PropertyType.GenericTypeArguments[0];

            var listType = typeof(List<>).MakeGenericType(toItemType);
            var result = Activator.CreateInstance(listType);

            foreach (var item in (ICollection)sourceProp.GetValue(source))
            {
                object collectionItem = Get(toItemType, fromItemType, item);
                result.GetType().GetMethod("Add").Invoke(result, new[] { collectionItem });
            }
            return result;
        }

        #region checks
        private bool IsMapped(Type type)
        {
            return types.Any(x => x.Item1 == type || x.Item2 == type);
        }

        private bool IsClass(Type type)
        {
            return type != typeof(string) && type.IsClass && IsMapped(type);
        }

        private bool IsCollection(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>);
        }
        #endregion

        #region conflicts
        private void SetConflicting(Type TBase, object value)
        {
            var conflictBase = conflicts.SingleOrDefault(x => x.Key.Item1 == TBase);
            if (conflictBase.Key != null && conflictBase.Value == null)
            {
                conflicts[conflictBase.Key] = value;
            }
        }

        private bool CheckConflict(Type TChild, Type TConflicting, out KeyValuePair<Tuple<Type, Type>, object> conflict)
        {
            conflict = conflicts.SingleOrDefault(x => x.Key.Item2 == TChild && x.Key.Item1 == TConflicting);
            return conflict.Value != null;
        }
        #endregion
    }
}
