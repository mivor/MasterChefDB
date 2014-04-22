using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb
{
    public class ConcurentMapping : EntityTypeConfiguration<Concurent>
    {
        public ConcurentMapping()
        {
            HasOptional(x => x.Echipa).WithMany(x => x.Concurenti)
                                      .WillCascadeOnDelete(false);
        }
    }
}
