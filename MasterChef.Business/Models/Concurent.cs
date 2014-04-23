using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefDb
{
    public class Concurent : Persoana
    {
        public virtual Echipa Echipa { get; set; }
    }
}
