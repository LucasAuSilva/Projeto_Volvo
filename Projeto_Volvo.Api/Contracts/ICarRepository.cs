using Projeto_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Contracts
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<ICollection<Car>> GetCarsPerKmAndSystemVersion(int km, string versionSystem);
    }
}