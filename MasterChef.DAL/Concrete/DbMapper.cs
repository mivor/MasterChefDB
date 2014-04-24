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
        private Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        
        // problemType - baseType: count

        public void Map<TSource, TResult>()
        {
            types.Add(typeof(TResult), typeof(TSource));
        }

        public TResult Get<TSource, TResult>(TSource source) where TResult : new()
        {
            var result = new TResult();
            foreach (var prop in typeof(TSource).GetProperties())
            {
                var propInfo = typeof(TResult).GetProperty(prop.Name);
                if (propInfo != null)
                {
                    Type toType = propInfo.PropertyType;
                    if (toType != typeof(string) && toType.IsClass && types.ContainsKey(toType))
                    {
                        object subType = toType.GetConstructor(new Type[] { }).Invoke(null);
                        subType = typeof(DbMapper).GetMethod("Get").MakeGenericMethod(new Type[] { prop.PropertyType, toType }).Invoke(this, new object[] { prop.GetValue(source)});
                        propInfo.SetValue(result, subType);
                    }
                    else if (toType.IsGenericType && toType.GetGenericTypeDefinition() == typeof(ICollection<>) && prop.GetValue(source) != null )
                    {
                        var toItemType = toType.GenericTypeArguments[0];
                        var fromItemType = prop.PropertyType.GenericTypeArguments[0];
                        var listType = typeof(List<>).MakeGenericType(toItemType);
                        var subType = Activator.CreateInstance(listType);
                        foreach (var item in (ICollection)prop.GetValue(source))
                        {
                            object collectionItem = toItemType.GetConstructor(new Type[] { }).Invoke(null);
                            collectionItem = typeof(DbMapper).GetMethod("Get").MakeGenericMethod(new Type[] { fromItemType, toItemType }).Invoke(this, new object[] { item });
                            subType.GetType().GetMethod("Add").Invoke(subType, new[] { collectionItem });
                        }
                        propInfo.SetValue(result, subType);
                    }
                    else
                        propInfo.SetValue(result, prop.GetValue(source));
                }
            }
            return result;
        }
    }
}
