using System.Data.Entity;

namespace MasterChefDb
{
    public class MasterChefDataContext : DbContext
    {
        public DbSet<Persoana> Persoane { get; set; }
        public DbSet<Echipa> Echipe { get; set; }

        public MasterChefDataContext()
            : base("MasterChefDatabaseConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PersoaneMapping());
            modelBuilder.Configurations.Add(new ConcurentMapping());
            modelBuilder.Configurations.Add(new EchipaMapping());

            modelBuilder.Entity<Concurent>().ToTable("Concurenti");
            modelBuilder.Entity<Chef>().ToTable("Chefs");
            modelBuilder.Entity<Jurat>().ToTable("Jurati");

            //modelBuilder.Entity<Echipa>().HasOptional(X => X.Chef).WithOptionalDependent(x => x.Echipa);

            modelBuilder.Entity<Evaluare>().ToTable("Evaluari");
        }
    }
}
