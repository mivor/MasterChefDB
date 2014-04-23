
namespace MasterChefDb.Business.Models
{
    public class Evaluare : BaseModel
    {
        public Echipa Echipa { get; private set; }
        public Jurat Jurat { get; private set; }
        public decimal Nota { get; private set; }

        public Evaluare()
        {
        }

        public Evaluare(Jurat jurat, Echipa echipa, decimal nota)
        {
            Echipa = echipa;
            Jurat = jurat;
            Nota = nota;
        }
    }
}
