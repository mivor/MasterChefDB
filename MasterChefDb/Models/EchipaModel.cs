using System.Collections.Generic;
using System.Linq;

namespace MasterChefDb.Models
{
    public class EchipaModel : BaseModel
    {
        public virtual ICollection<ConcurentModel> Concurenti { get; set; }
        public virtual ICollection<EvaluareModel> Evaluari { get; set; }
        public virtual ChefModel Chef { get;  set; }
    }
}
