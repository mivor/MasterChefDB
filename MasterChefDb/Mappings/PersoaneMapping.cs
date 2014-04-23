using MasterChefDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb.Mappings
{
    public class PersoaneMapping : EntityTypeConfiguration<Persoana>
    {
        public PersoaneMapping()
        {
            ToTable("Persoane");
        }
    }
}
