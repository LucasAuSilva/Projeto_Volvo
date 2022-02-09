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
            if (dto.Categories == null)
            {
                throw new EntityException("Acessorio não pode ser criado sem uma categoria.", 400);
            }
            foreach (var category in dto.Categories)
            {
                if (category.IdCategory.HasValue)
                {
                    var findCategory = await categoryRepo.GetOneEntity((int)category.IdCategory);
                    acessory.Categories.Add(findCategory);
                }
                else
                {
                    acessory.Categories.Add(category.CreateEntity());
                }
            }

            return acessory;
        }
    }
}