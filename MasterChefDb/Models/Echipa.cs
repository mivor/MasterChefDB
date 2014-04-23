using System.Collections.Generic;
using System.Linq;

namespace MasterChefDb.Models
{
    public class Echipa : BaseModel
    {
        public virtual ICollection<Concurent> Concurenti { get; set; }
        public virtual ICollection<Evaluare> Evaluari { get; set; }
        public virtual Chef Chef { get;  set; }
    }
}
