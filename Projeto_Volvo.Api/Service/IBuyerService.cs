using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public interface IBuyerService
    {
        Task<Buyer> CreateBuyer(BuyerDto dto);
    }
}