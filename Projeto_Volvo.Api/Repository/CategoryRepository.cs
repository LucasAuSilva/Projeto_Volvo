using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(VolvoContext context) : base(context)
        {
        }
    }
}