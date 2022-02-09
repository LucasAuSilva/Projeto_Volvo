using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class CategoryDto : IDto<Category>
    {
        public int? IdCategory { get; set; }
        public string? Name { get; set; }

        public Category CreateEntity()
        {
            return new Category()
            {
                Name = this.Name
            };
        }
    }
}