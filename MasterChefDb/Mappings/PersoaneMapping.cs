using MasterChefDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb
{
    public class PersoaneMapping : EntityTypeConfiguration<Persoana>
    {
        public PersoaneMapping()
        {
            ToTable("Persoane");
            Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }
}
