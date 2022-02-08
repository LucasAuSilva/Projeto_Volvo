
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public interface IWorkerService
    {
        Task<Worker> CreateWorker(IAddressRepository addressRepo, IContactRepository contactRepo, IDealershipRepository dealershipRepo, WorkerDto dto);
    }
}