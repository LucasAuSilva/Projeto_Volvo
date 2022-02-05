using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class AcessoriesCategoryRepository : BaseRepository<AcessoriesCategory>
    {
        public AcessoriesCategoryRepository(VolvoContext context) : base(context)
        {
        }
    }
}