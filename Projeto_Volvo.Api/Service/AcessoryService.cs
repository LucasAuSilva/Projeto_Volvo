using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public class AcessoryService : IAcessoryService
    {
        private readonly ICategoryRepository categoryRepo;

        public AcessoryService(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task<Acessory> CreateAcessory(AcessoryDto dto)
        {
            var acessory = dto.CreateEntity();

            if (dto.Category == null)
            {
                throw new EntityException("Categoria não pode ser vazio", 400);
            }
            else if (dto.Category.IdCategory.HasValue)
            {
                var category = await categoryRepo.GetOneEntity((int)dto.Category.IdCategory);
            }

            return acessory;
        }
    }
}