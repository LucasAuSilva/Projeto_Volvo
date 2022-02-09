using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public interface ICarService
    {
        Task<Car> CreateCar(CarDto dto);
    }
}