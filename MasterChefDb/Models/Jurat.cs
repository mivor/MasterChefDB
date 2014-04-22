using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefDb
{
    public class Jurat : Persoana
    {
        public int Nivel { get; set; }

        public void Evalueaza(Echipa echipa)
        {
            decimal nota = echipa.Chef.Stele * echipa.Concurenti.Count - Nivel;
            echipa.AddEvaluare(this, nota);
        }
    }
}
