using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class WorkerDto : IDto<Worker>
    {
        public string? Name { get; set; }
        public float BaseSalary { get; set; }
        public string? Cpf { get; set; }
        public float Commission { get; set; }
        public int Level { get; set; }
        public virtual AddressDto? Address { get; set; }
        public virtual ContactDto? Contact { get; set; }
        public virtual DealershipDto? DealershipDto { get; set; }

        public Worker CreateEntity()
        {
            return new Worker()
            {
                Name = this.Name,
                BaseSalary = this.BaseSalary,
                Cpf = this.Cpf,
                Commission = this.Commission,
                Level = this.Level,
                Address = this.Address == null ? null : this.Address.CreateEntity(),
                Dealership = this.DealershipDto == null ? null : this.DealershipDto.CreateEntity()
            };
        }
    }
}