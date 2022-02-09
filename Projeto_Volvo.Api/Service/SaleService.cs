
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public class SaleService : ISaleService
    {
        private readonly IDealershipRepository dealershipRepo;
        private readonly IWorkerRepository workerRepo;
        private readonly ICarRepository carRepo;
        private IBuyerRepository buyerRepo;

        public SaleService(
            IDealershipRepository dealershipRepo,
            IWorkerRepository workerRepo,
            ICarRepository carRepo,
            IBuyerRepository buyerRepo
        )
        {
            this.dealershipRepo = dealershipRepo;
            this.workerRepo = workerRepo;
            this.carRepo = carRepo;
            this.buyerRepo = buyerRepo;
        }

        public async Task<Sale> CreateSale(
            SaleDto dto
            )
        {
            var buyer = await buyerRepo.GetOneEntity(dto.idBuyer);
            var worker = await workerRepo.GetOneEntity(dto.idWorker);
            var dealership = await dealershipRepo.GetOneEntity(dto.idDealership);
            var car = await carRepo.GetOneEntity(dto.idCar);

            var sale = dto.CreateEntity(worker, dealership, buyer, car);
            return sale;
        }
    }
}
