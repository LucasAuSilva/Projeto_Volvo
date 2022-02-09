using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class OwnerDto : IDto<Owner>
    {
        public int? IdOwner { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public virtual AddressDto? Address { get; set; }
        public virtual ContactDto? Contact { get; set; }

        public Owner CreateEntity()
        {
            return new Owner()
            {
                Name = this.Name != null ? this.Name.ToLower() : this.Name,
                Cpf = this.Cpf,
                Cnpj = this.Cnpj,
                Address = this.Address == null ? null : this.Address.CreateEntity(),
                Contact = this.Contact == null ? null : this.Contact.CreateEntity()
            };
        }
    }
}