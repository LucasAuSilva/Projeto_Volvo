using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IAddressRepository addressRepo;
        private readonly IContactRepository contactRepo;

        public OwnerService(
            IAddressRepository addressRepo,
            IContactRepository contactRepo
        )
        {
            this.addressRepo = addressRepo;
            this.contactRepo = contactRepo;
        }

        public async Task<Owner> CreateOwner(OwnerDto dto)
        {
            var owner = dto.CreateEntity();
            if (dto.Address != null && dto.Address.IdAddress.HasValue)
            {
                var address = await addressRepo.GetOneEntity((int)dto.Address.IdAddress);
                owner.Address = address;
            }
            if (dto.Contact != null && dto.Contact.IdContact.HasValue)
            {
                var contact = await contactRepo.GetOneEntity((int)dto.Contact.IdContact);
                owner.Contact = contact;
            }

            return owner;
        }
    }
}