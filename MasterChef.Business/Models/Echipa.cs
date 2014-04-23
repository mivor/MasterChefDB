using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefDb
{
    public class Echipa : BaseModel
    {
        public string Nume { get; set; }
        public virtual ICollection<Concurent> Concurenti { get; private set; }
        public virtual ICollection<Evaluare> Evaluari { get; private set; }
        
        public virtual Chef Chef { get;  set; }

        public decimal MedieEchipa
        { 
            get { return Evaluari.Sum( e => e.Nota); } 
            private set {}
        }

        public Echipa()
        {
            Concurenti = new List<Concurent>();
            Evaluari = new HashSet<Evaluare>();
        }

        public Echipa(string nume) : this()
        {
            Nume = nume;
        }


        public void AddConcurent(Concurent concurent)
        {
            concurent.Echipa = this;
            if (concurent is Chef && this.Chef == null)
                Chef = (Chef)concurent;
            //Concurenti.Add(concurent);
            else
                Concurenti.Add(concurent);
        }

        public void AddEvaluare(Jurat jurat, decimal nota)
        {
            Evaluari.Add(new Evaluare(jurat,this,nota));
        }
    }
}
