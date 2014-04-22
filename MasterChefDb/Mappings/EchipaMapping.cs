using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb
{
    public class EchipaMapping : EntityTypeConfiguration<Echipa>
    {
        public EchipaMapping()
        {
            ToTable("Echipe");
            Ignore(x => x.Chef);
        }
    }
}
