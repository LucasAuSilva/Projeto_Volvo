using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class AddressDto : IDto<Address>
    {
        public int? IdAddress { get; set; }
        public string? Street { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public int CodeCity { get; set; }
        public string? State { get; set; }
        public int CodeState { get; set; }
        public string? Cep { get; set; }

        public Address CreateEntity()
        {
            return new Address()
            {
                Street = this.Street,
                District = this.District,
                City = this.City,
                CodeCity = this.CodeCity,
                State = this.State,
                CodeState = this.CodeState,
                Cep = this.Cep
            };
        }
    }
}