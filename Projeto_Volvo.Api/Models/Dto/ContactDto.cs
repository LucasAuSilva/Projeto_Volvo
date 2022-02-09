using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class ContactDto : IDto<Contact>
    {
        public int? IdContact { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }

        public Contact CreateEntity()
        {
            return new Contact()
            {
                Phone = this.Phone,
                Fax = this.Fax,
                Email = this.Email
            };
        }
    }
}