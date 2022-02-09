
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public interface IDealershipService
    {
        Task<Dealership> CreateDealership(DealershipDto dto);
    }
}