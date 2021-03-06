﻿using MasterChefDb.Mappings;
using MasterChefDb.Models;
using System.Data.Entity;

namespace MasterChefDb
{
    public class MasterChefDataContext : DbContext
    {
        public DbSet<PersoanaModel> Persoane { get; set; }
        public DbSet<EchipaModel> Echipe { get; set; }

        public MasterChefDataContext()
            : base("MasterChefDatabaseConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PersoaneMapping());
            modelBuilder.Configurations.Add(new BaseMapping());

            modelBuilder.Configurations.Add(new ConcurentMapping());
            modelBuilder.Configurations.Add(new ChefMappings());
            modelBuilder.Configurations.Add(new ConcursMapping());


            modelBuilder.Entity<EchipaModel>().ToTable("Echipe");
            modelBuilder.Entity<JuratModel>().ToTable("Jurati");
            modelBuilder.Entity<EvaluareModel>().ToTable("Evaluari");
        }
    }
}
