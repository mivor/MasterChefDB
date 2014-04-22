using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MasterChefDb.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MasterChefDb.MasterChefDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MasterChefDb.MasterChefDataContext context)
        {
            context.Persoane.Add(new Concurent { Name = "JAAAAhon" });
        }
    }
}
