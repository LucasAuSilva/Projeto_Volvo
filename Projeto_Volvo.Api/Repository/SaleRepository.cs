using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private VolvoContext context;
        private bool disposed = false;

        public SaleRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<Sale> AddEntity(Sale entity)
        {
            await context.Set<Sale>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Sale>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Sale>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Venda não encontrada.");
        }

        public async Task<ICollection<Sale>> GetAllEntity()
        {
            var entities = await context.Set<Sale>().ToListAsync<Sale>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Sale> GetOneEntity(int id)
        {
            var entity = await context.Set<Sale>()
                .Include("Buyer")
                .Include("Car")
                .Include("Dealership")
                .Include("Worker")
                .SingleAsync(s => s.IdSale == id);

            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Venda não encontrada.");
        }

        public async Task<Sale> UpdateEntity(int id, Sale entity)
        {
            var oldEntity = await context.Set<Sale>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Sale>(oldEntity).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            throw new EntityException("Venda não encontrada.");
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