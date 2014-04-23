using System.Data.Entity;
using MasterChefDb.Models;

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
