using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IAddressRepository addressRepo;
        private readonly IContactRepository contactRepo;
        private readonly IDealershipRepository dealershipRepo;

        public WorkerService(
            IAddressRepository addressRepo,
            IContactRepository contactRepo,
            IDealershipRepository dealershipRepo
        )
        {
            this.addressRepo = addressRepo;
            this.contactRepo = contactRepo;
            this.dealershipRepo = dealershipRepo;
        }

        public async Task<Worker> CreateWorker(WorkerDto dto)
        {
            var worker = dto.CreateEntity();
            if (dto.Dealership != null && dto.Dealership.IdDealership.HasValue)
            {
                var dealership = await dealershipRepo.GetOneEntity((int)dto.Dealership.IdDealership);
                worker.Dealership = dealership;
            }
            if (dto.Contact != null && dto.Contact.IdContact.HasValue)
            {
                var contact = await contactRepo.GetOneEntity((int)dto.Contact.IdContact);
                worker.Contact = contact;
            }
            if (dto.Address != null && dto.Address.IdAddress.HasValue)
            {
                var address = await addressRepo.GetOneEntity((int)dto.Address.IdAddress);
                worker.Address = address;
            }

            return worker;
        }
    }
}