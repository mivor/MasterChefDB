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
    class DbMapper
    {
        public TResult Convert<TSource, TResult>(TSource source) where TResult : new()
        {
            var result = new TResult();
            foreach (var prop in typeof(EchipaModel).GetProperties())
            {
                PropertyInfo propInfo = result.GetType().GetProperty(prop.Name, prop.PropertyType);

                if (propInfo != null)
                {
                    propInfo.SetValue(result, prop.GetValue(source));
                }
            }
            return result;
        }
    }
}
