using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class ContactRepository : BaseRepository<Contact>
    {
        public ContactRepository(VolvoContext context) : base(context)
        {
        }
    }
}