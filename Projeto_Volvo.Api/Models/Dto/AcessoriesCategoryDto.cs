namespace Projeto_Volvo.Api.Models.Dto
{
    public class AcessoriesCategoryDto
    {
        public int? IdAcessoriesCategory { get; set; }
        public virtual AcessoryDto? Acessorie { get; set; }
        public virtual CategoryDto? Category { get; set; }
    }
}