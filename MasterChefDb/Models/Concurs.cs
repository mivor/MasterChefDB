using MasterChefDb.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MasterChef.Models
{
    public class Concurs : BaseModel
    {
        public virtual ICollection<Echipa> Echipe { get; set; }
    }
}
