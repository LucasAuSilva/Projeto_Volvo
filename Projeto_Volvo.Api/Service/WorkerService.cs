using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public class WorkerService : IWorkerService
    {
        public async Task<Worker> CreateWorker(
            IAddressRepository addressRepo,
            IContactRepository contactRepo,
            IDealershipRepository dealershipRepo,
            WorkerDto dto
        )
        {
            var worker = dto.CreateEntity();
            if (dto.Dealership != null && dto.Dealership.IdDealership != null)
            {
                var dealership = await dealershipRepo.GetOneEntity(dto.Dealership.IdDealership);
                worker.Dealership = dealership;
            }
            if (dto.Contact != null && dto.Contact.IdContact != null)
            {
                var contact = await contactRepo.GetOneEntity(dto.Contact.IdContact);
                worker.Contact = contact;
            }
            if (dto.Address != null && dto.Address.IdAddress != null)
            {
                var address = await addressRepo.GetOneEntity(dto.Address.IdAddress);
                worker.Address = address;
            }

            return worker;
        }
    }
}