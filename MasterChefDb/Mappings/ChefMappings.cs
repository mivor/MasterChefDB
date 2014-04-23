using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb.Mappings
{
    public class ChefMappings : EntityTypeConfiguration<Chef>
    {
        public ChefMappings()
        {
            HasOptional(x => x.Echipa).WithRequired(x => x.Chef);
        }
    }
}
