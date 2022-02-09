using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Service
{
    public interface IOwnerService
    {
        Task<Owner> CreateOwner(OwnerDto dto);
    }
}