
namespace MasterChefDb.Business.Models
{
    public class Chef : Persoana
    {
        public virtual Echipa Echipa { get; set; }
        public string Specializare { get; set; }
        public int Stele { get; set; }
    }
}
