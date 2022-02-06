using Projeto_Curso_Volvo.Api.Models;
using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Repository
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(VolvoContext context) : base(context)
        { }
    }
}