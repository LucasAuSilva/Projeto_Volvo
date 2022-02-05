using Projeto_Curso_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class CarRepository : BaseRepository<Car>
    {
        public CarRepository(VolvoContext context) : base(context)
        { }
    }
}