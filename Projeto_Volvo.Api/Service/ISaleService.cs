using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public interface ISaleService
    {
        Task<Sale> CreateSale(IBuyerRepository buyerRepo,
            IDealershipRepository dealershipRepo,
            IWorkerRepository workerRepo,
            ICarRepository carRepo,
            SaleDto dto);
    }
}