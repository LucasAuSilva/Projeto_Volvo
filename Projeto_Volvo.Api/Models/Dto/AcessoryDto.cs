using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class AcessoryDto : IDto<Acessory>
    {
        public int? IdAcessory { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual CategoryDto? Category { get; set; }

        public Acessory CreateEntity()
        {
            return new Acessory()
            {
                Name = this.Name,
                Description = this.Description,
                Category = this.Category == null ? null : this.Category.CreateEntity()
            };
        }
    }
}