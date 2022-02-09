using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class WorkerDto : IDto<Worker>
    {
        public int? IdWorker { get; set; }
        public string? Name { get; set; }
        public float BaseSalary { get; set; }
        public string? Cpf { get; set; }
        public float Commission { get; set; }
        public int Level { get; set; }
        public virtual AddressDto? Address { get; set; }
        public virtual ContactDto? Contact { get; set; }
        public virtual DealershipDto? Dealership { get; set; }

        public Worker CreateEntity()
        {
            return new Worker()
            {
                Name = this.Name != null ? this.Name.ToLower() : this.Name,
                BaseSalary = this.BaseSalary,
                Cpf = this.Cpf,
                Commission = this.Commission,
                Level = Enum.EnumLevel.Funcionario,
                Address = this.Address == null ? null : this.Address.CreateEntity(),
                Contact = this.Contact == null ? null : this.Contact.CreateEntity(),
                Dealership = this.Dealership == null ? null : this.Dealership.CreateEntity()
            };
        }
    }
}