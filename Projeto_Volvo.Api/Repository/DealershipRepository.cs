using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class DealershipRepository : BaseRepository<Dealership>
    {
        public DealershipRepository(VolvoContext context) : base(context)
        {
        }
    }
}