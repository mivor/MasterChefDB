using MasterChef.Models;
using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb
{
    public class ConcursMapping : EntityTypeConfiguration<Concurs>
    {
        public ConcursMapping()
        {
            ToTable("Concursuri");
            HasMany(x => x.Echipe);
        }
    }
}
