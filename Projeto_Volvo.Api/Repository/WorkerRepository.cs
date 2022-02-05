using Microsoft.EntityFrameworkCore;
using Projeto_Curso_Volvo.Api.Models;
using Projeto_Volvo.Api.Exceptions;

namespace Projeto_Volvo.Api.Repository
{
    public class WorkerRepository : BaseRepository<Worker>
    {
        public WorkerRepository(VolvoContext context) : base(context)
        {
        }

        public async Task<ICollection<Sale>> GetSalesOnMonth(int workerId, DateTime month)
        {
            var worker = await context.Workers.FindAsync(workerId);
            if (worker != null)
            {
                var sales = worker.Sales
                    .Where(s => s.Data.Month == month.Month)
                    .ToList();

                return sales;
            }

            throw new EntityException("Entidade não encontrada.");
        }
    }
}