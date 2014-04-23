
namespace MasterChefDb.Models
{
    public class ChefModel : PersoanaModel
    {
        public virtual EchipaModel Echipa { get; set; }
        public string Specializare { get; set; }
        public int Stele { get; set; }
    }
}
