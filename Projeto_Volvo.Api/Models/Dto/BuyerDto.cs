using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class BuyerDto : IDto<Buyer>
    {
        public int IdBuyer { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public virtual AddressDto? Address { get; set; }
        public virtual ContactDto? Contact { get; set; }

        public Buyer CreateEntity()
        {
            return new Buyer()
            {
                Name = this.Name,
                Cpf = this.Cpf,
                Address = this.Address == null ? null : Address.CreateEntity(),
                Contact = this.Contact == null ? null : Contact.CreateEntity()
            };
        }
    }
}