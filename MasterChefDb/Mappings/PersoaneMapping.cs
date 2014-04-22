using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb
{
    public class PersoaneMapping : EntityTypeConfiguration<Persoana>
    {
        public PersoaneMapping()
        {
            //Map(x => { x.ToTable("Persoane"); x.Requires("Discriminator").HasValue("persoana"); })
            //.Map<Jurat>(x => x.Requires("Discriminator").HasValue("jurat"))
            //.Map<Concurent>(x => x.Requires("Discriminator").HasValue("concurent"))
            //.Map<Chef>(x => x.Requires("Discriminator").HasValue("chef"));

            ToTable("Persoane");
            Property(x => x.Name).HasMaxLength(150).IsRequired();

            HasKey(x => x.Id);
        }
    }
}
