using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefDb
{
    public class Concurent : Persoana
    {
        // navigation 
        //public virtual int? EchipaId { get; set; }
        public virtual Echipa Echipa { get; set; }
    }
}
