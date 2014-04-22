using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefDb
{
    public class Chef : Concurent
    {
        public string Specializare { get; set; }
        public int Stele { get; set; }
    }
}
