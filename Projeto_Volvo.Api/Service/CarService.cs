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
        private readonly IAcessoryService acessoryService;

        public CarService(
            IOwnerRepository ownerRepo,
            IAcessoryRepository acessoryRepo,
            IAcessoryService acessoryService
        )
        {
            this.ownerRepo = ownerRepo;
            this.accessoryRepo = acessoryRepo;
            this.acessoryService = acessoryService;
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

            if (dto.Acessories == null)
            {
                throw new EntityException("Acessorios devem ser preenchidos.", 400);
            }
            foreach (var acessory in dto.Acessories)
            {
                if (acessory.IdAcessory.HasValue)
                {
                    var findAcessory = await accessoryRepo.GetOneEntity((int)acessory.IdAcessory);
                    car.Acessories.Add(findAcessory);
                }
                else
                {
                    var newAcessory = await acessoryService.CreateAcessory(acessory);
                    car.Acessories.Add(newAcessory);
                }
            }

            return car;
        }
    }
}