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
            modelBuilder.Configurations.Add(new ChefMappings());
            modelBuilder.Configurations.Add(new ConcursMapping());


            modelBuilder.Entity<Echipa>().ToTable("Echipe");
            modelBuilder.Entity<Jurat>().ToTable("Jurati");
            modelBuilder.Entity<Evaluare>().ToTable("Evaluari");
        }
    }
}
