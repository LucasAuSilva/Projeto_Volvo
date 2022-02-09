using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public class BuyerService : IBuyerService
    {
        private readonly IContactRepository contactRepo;
        private readonly IAddressRepository addressRepo;

        public BuyerService(IContactRepository contactRepo, IAddressRepository addressRepo)
        {
            this.contactRepo = contactRepo;
            this.addressRepo = addressRepo;
        }

        public async Task<Buyer> CreateBuyer(BuyerDto dto)
        {
            var buyer = dto.CreateEntity();
            if (dto.Address != null && dto.Address.IdAddress.HasValue)
            {
                var address = await addressRepo.GetOneEntity((int)dto.Address.IdAddress);
                buyer.Address = address;
            }
            if (dto.Contact != null && dto.Contact.IdContact.HasValue)
            {
                var contact = await contactRepo.GetOneEntity((int)dto.Contact.IdContact);
                buyer.Contact = contact;
            }

            return buyer;
        }
    }
}