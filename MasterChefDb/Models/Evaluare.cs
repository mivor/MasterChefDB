
namespace MasterChefDb.Models
{
    public class Evaluare : BaseModel
    {
        public Echipa Echipa { get; set; }
        public Jurat Jurat { get; set; }
        public decimal Nota { get; set; }
    }
}
