using MasterChefDb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef
{
    public class Concurs : BaseModel
    {
        public virtual ICollection<Echipa> Echipe { get; private set; }
                
        public Concurs()
        {
            Echipe = new Collection<Echipa>();
        }

    }
}
