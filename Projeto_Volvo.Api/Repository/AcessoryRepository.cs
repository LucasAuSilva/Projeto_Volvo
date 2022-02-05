using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class AcessoryRepository : BaseRepository<Acessory>
    {
        public AcessoryRepository(VolvoContext context) : base(context)
        {
        }
    }
}