using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Repository
{
    public class WorkerRepository : IWorkerRepository
    {
        private VolvoContext context;
        private bool disposed = false;

        public WorkerRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Sale>> GetSalesOnMonth(int workerId, DateTime month)
        {
            var worker = await context.Workers
                .Include("Sales")
                .SingleAsync(w => w.IdWorker == workerId);

            if (worker != null)
            {
                var sales = worker.Sales
                    .Where(s => s.Data.Month == month.Month)
                    .ToList();

                return sales;
            }

            throw new EntityException($"Worker com Id {workerId} não encontrada.");
        }

        public async Task<Worker> AddEntity(Worker entity)
        {
            await context.Set<Worker>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Worker>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Worker>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Vendedor não encontrado.");
        }

        public async Task<ICollection<Worker>> GetAllEntity()
        {
            var entities = await context.Set<Worker>().ToListAsync<Worker>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Worker> GetOneEntity(int id)
        {
            var entity = await context
                .Set<Worker>()
                .Include("Contact")
                .Include("Address")
                .Include("Dealership")
                .Include("Sales")
                .SingleAsync(w => w.IdWorker == id);

            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Vendedor não encontrado.");
        }

        public async Task<Worker> UpdateEntity(int id, Worker entity)
        {
            var oldEntity = await context.Set<Worker>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Worker>(oldEntity).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            throw new EntityException("Vendedor não encontrado.", 400);
        }

        protected async virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    await context.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}