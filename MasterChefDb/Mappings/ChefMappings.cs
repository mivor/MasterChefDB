using MasterChefDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb.Mappings
{
    public class ChefMappings : EntityTypeConfiguration<Chef>
    {
        public ChefMappings()
        {
            ToTable("Chefs");
            HasOptional(x => x.Echipa).WithOptionalPrincipal(x => x.Chef).WillCascadeOnDelete(false);
        }
    }
}
