using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChef.Business.Models;
using MasterChefDb.Models;
using System.Reflection;

namespace MasterChef.DAL.Concrete
{
    public class DbMapper
    {
        // dest - source
        private Dictionary<Type, Type> types = new Dictionary<Type, Type>();

        public void Map<TSource, TResult>()
        {
            types.Add(typeof(TResult), typeof(TSource));
        }

        public TResult Get<TSource, TResult>(TSource source) where TResult : new()
        {
            var result = new TResult();
            foreach (var prop in typeof(TSource).GetProperties())
            {
                PropertyInfo propInfo = typeof(TResult).GetProperty(prop.Name);
                if (propInfo != null)
                {
                    Type toType = propInfo.PropertyType;
                    if (toType != typeof(string) && toType.IsClass && types.ContainsKey(toType))
                    {
                        object subType = toType.GetConstructor(new Type[] { }).Invoke(null);
                        subType = typeof(DbMapper).GetMethod("Get").MakeGenericMethod(new Type[] { prop.PropertyType, toType }).Invoke(this, new object[] {prop.PropertyType});
                        propInfo.SetValue(result, subType);
                    }
                    propInfo.SetValue(result, prop.GetValue(source));
                }
            }
            return result;
        }
    }
}
