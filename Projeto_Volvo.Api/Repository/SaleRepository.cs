using Microsoft.EntityFrameworkCore;
using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class SaleRepository : BaseRepository<Sale>
    {
        public SaleRepository(VolvoContext context) : base(context)
        {
        }
    }
}