using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class BuyerRepository : BaseRepository<Buyer>
    {
        public BuyerRepository(VolvoContext context) : base(context)
        {
        }
    }
}