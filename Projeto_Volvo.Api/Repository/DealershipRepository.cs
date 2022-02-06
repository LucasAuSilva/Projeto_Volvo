using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class DealershipRepository : IDealershipRepository
    {
        protected VolvoContext context;
        private bool disposed = false;

        protected DealershipRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<Dealership> AddEntity(Dealership entity)
        {
            await context.Set<Dealership>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Dealership>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Dealership>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<ICollection<Dealership>> GetAllEntity()
        {
            var entities = await context.Set<Dealership>().ToListAsync<Dealership>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Dealership> GetOneEntity(int id)
        {
            var entity = await context.Set<Dealership>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<Dealership> UpdateEntity(int id, Dealership entity)
        {
            var oldEntity = await context.Set<Dealership>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Dealership>(oldEntity).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            throw new EntityException("Entidade não encontrada.");
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