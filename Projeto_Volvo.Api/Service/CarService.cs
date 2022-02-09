using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public class CarService : ICarService
    {
        private readonly IOwnerRepository ownerRepo;
        private readonly IAcessoryRepository accessoryRepo;

        public CarService(
            IOwnerRepository ownerRepo,
            IAcessoryRepository acessoryRepo
        )
        {
            this.ownerRepo = ownerRepo;
            this.accessoryRepo = acessoryRepo;
        }

        public async Task<Car> CreateCar(CarDto dto)
        {
            var car = dto.CreateEntity();

            if (dto.Owner == null)
            {
                throw new EntityException("Proprietário não pode ser vazio.", 400);
            }
            else if (dto.Owner.IdOwner.HasValue)
            {
                var owner = await ownerRepo.GetOneEntity((int)dto.Owner.IdOwner);
                car.Owner = owner;
            }

            return car;
        }
    }
}