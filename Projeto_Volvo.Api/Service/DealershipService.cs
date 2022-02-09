using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public class DealershipService : IDealershipService
    {
        private readonly IAddressRepository addressRepo;
        private readonly IContactRepository contactRepo;

        public DealershipService(
            IAddressRepository addressRepo,
            IContactRepository contactRepo
        )
        {
            this.addressRepo = addressRepo;
            this.contactRepo = contactRepo;
        }

        public async Task<Dealership> CreateDealership(DealershipDto dto)
        {
            var dealership = dto.CreateEntity();
            if (dto.Address != null && dto.Address.IdAddress.HasValue)
            {
                var address = await addressRepo.GetOneEntity((int)dto.Address.IdAddress);
                dealership.Address = address;
            }
            if (dto.Contact != null && dto.Contact.IdContact.HasValue)
            {
                var contact = contactRepo.GetOneEntity((int)dto.Contact.IdContact);
                dealership.Contact = await contact;
            }
            return dealership;
        }
    }
}