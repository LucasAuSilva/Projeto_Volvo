using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class OwnerRepository : BaseRepository<Owner>
    {
        public OwnerRepository(VolvoContext context) : base(context)
        {
        }
    }
}