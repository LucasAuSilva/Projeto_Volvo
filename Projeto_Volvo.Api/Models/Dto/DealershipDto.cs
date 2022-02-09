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

        public Dealership CreateEntity()
        {
            return new Dealership()
            {
                Name = this.Name,
                Cnpj = this.Cnpj,
                Address = this.Address == null ? null : Address.CreateEntity(),
                Contact = this.Contact == null ? null : Contact.CreateEntity()
            };
        }
    }
}