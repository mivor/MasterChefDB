
namespace MasterChefDb.Models
{
    public class EvaluareModel : BaseModel
    {
        public EchipaModel Echipa { get; set; }
        public JuratModel Jurat { get; set; }
        public decimal Nota { get; set; }
    }
}
