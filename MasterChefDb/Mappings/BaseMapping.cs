using MasterChefDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefDb.Mappings
{
    public class BaseMapping : EntityTypeConfiguration<Persoana>
    {
        public BaseMapping()
        {
            Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }
}
