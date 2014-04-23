using MasterChefDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb.Mappings
{
    public class PersoaneMapping : EntityTypeConfiguration<PersoanaModel>
    {
        public PersoaneMapping()
        {
            ToTable("Persoane");
        }
    }
}
