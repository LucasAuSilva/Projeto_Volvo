using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class AddressRepository : BaseRepository<Address>
    {
        public AddressRepository(VolvoContext context) : base(context)
        {
        }
    }
}