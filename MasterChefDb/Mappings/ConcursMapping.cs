using MasterChefDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb.Mappings
{
    public class ConcursMapping : EntityTypeConfiguration<ConcursModel>
    {
        public ConcursMapping()
        {
            ToTable("Concursuri");
            HasMany(x => x.Echipe);
        }
    }
}
