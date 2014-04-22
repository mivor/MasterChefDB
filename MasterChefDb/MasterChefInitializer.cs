using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MasterChefDb
{
    public class MasterChefInitializer :  DropCreateDatabaseAlways<MasterChefDataContext>
    {
        protected override void Seed(MasterChefDataContext context)
        {
            context.Persoane.Add(new Concurent { Name = "Jhon" });
        }
    }
}
