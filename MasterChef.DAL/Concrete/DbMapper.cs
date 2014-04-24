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
        // dest - source
        private List<Tuple<Type, Type>> types = new List<Tuple<Type, Type>>();

        // problemType - baseType: count
        private Dictionary<Tuple<Type, Type>, object> conflicts = new Dictionary<Tuple<Type, Type>, object>();

        public void Map<TSource, TResult>()
        {
            types.Add(Tuple.Create(typeof(TResult), typeof(TSource)));
        }

        public void Conflict<TBase, TChild>()
        {
            conflicts.Add(Tuple.Create(typeof(TBase), typeof(TChild)), null);
        }

        public TResult Get<TResult, TSource>(TSource source) where TResult : new()
        {
            var result = new TResult();
            

            foreach (var fromProp in typeof(TSource).GetProperties())
            {
                var toProp = typeof(TResult).GetProperty(fromProp.Name);

                if (toProp == null) continue;

                object value;
                var toType = toProp.PropertyType;
                var fromType = fromProp.PropertyType;
                
                var conflictChild = conflicts.SingleOrDefault(x => x.Key.Item2 == typeof(TSource) && x.Key.Item1 == fromType);

                if (conflictChild.Value != null)
                    value = conflictChild.Value;

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

        private object Get(Type toType, Type fromType, object source)
        {
            object result = toType.GetConstructor(new Type[] { }).Invoke(null);
            result = typeof(DbMapper).GetMethod("Get").MakeGenericMethod(new Type[] { toType, fromType }).Invoke(this, new object[] { source });
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

        private bool IsClass(Type type)
        {
            return type != typeof(string) && type.IsClass && types.Any(x => x.Item1 == type || x.Item2 == type);
        }

        private bool IsCollection(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>);
        }

        private bool SetConflicting<TBase>()
        {
            var conflictBase = conflicts.SingleOrDefault(x => x.Key.Item1 == typeof(TBase));
            if (conflictBase.Key != null && conflictBase.Value == null)
            {
                conflicts[conflictBase.Key] = result;
            }
        }

        private bool GetConflicting()
        {

        }
    }
}
