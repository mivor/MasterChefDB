using MasterChefDb.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MasterChefDb.Models
{
    public class ConcursModel : BaseModel
    {
        public virtual ICollection<EchipaModel> Echipe { get; set; }
    }
}
