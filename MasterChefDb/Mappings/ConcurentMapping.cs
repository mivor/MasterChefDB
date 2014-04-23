using MasterChefDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb.Mappings
{
    public class ConcurentMapping : EntityTypeConfiguration<ConcurentModel>
    {
        public ConcurentMapping()
        {
            ToTable("Concurenti");
            HasOptional(x => x.Echipa).WithMany(x => x.Concurenti)
                                      .WillCascadeOnDelete(false);
        }
    }
}
