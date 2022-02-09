using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class DealershipDto : IDto<Dealership>
    {
        public int? IdDealership { get; set; }
        public string? Name { get; set; }
        public string? Cnpj { get; set; }
        public virtual AddressDto? Address { get; set; }
        public virtual ContactDto? Contact { get; set; }

        public DealershipDto() { }

        public DealershipDto(Dealership dealership)
        {
            IdDealership = dealership.IdDealership;
            Name = dealership.Name;
            Cnpj = dealership.Cnpj;
            if (dealership.Address != null)
            {
                Address = new AddressDto(dealership.Address);
            }
            if (dealership.Contact != null)
            {
                Contact = new ContactDto(dealership.Contact);
            }
        }

        public Dealership CreateEntity()
        {
            return new Dealership()
            {
                Name = this.Name != null ? this.Name.ToLower() : this.Name,
                Cnpj = this.Cnpj,
                Address = this.Address == null ? null : Address.CreateEntity(),
                Contact = this.Contact == null ? null : Contact.CreateEntity()
            };
        }
    }
}