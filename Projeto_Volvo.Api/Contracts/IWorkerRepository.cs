using Projeto_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Contracts
{
    public interface IWorkerRepository : IBaseRepository<Worker>
    {
        Task<ICollection<Sale>> GetSalesOnMonth(int workerId, DateTime month);
    }
}