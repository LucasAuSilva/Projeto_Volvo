using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Contracts;
using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Exceptions;

namespace Projeto_Volvo.Api.Repository
{
    public class AcessoryRepository : IAcessoryRepository
    {
        private VolvoContext context;
        private bool disposed = false;

        public AcessoryRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<Acessory> AddEntity(Acessory entity)
        {
            await context.Set<Acessory>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Acessory>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Acessory>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<ICollection<Acessory>> GetAllEntity()
        {
            var entities = await context.Set<Acessory>().ToListAsync<Acessory>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Acessory> GetOneEntity(int id)
        {
            var entity = await context.Set<Acessory>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<Acessory> UpdateEntity(int id, Acessory entity)
        {
            var oldEntity = await context.Set<Acessory>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Acessory>(oldEntity).CurrentValues.SetValues(entity);
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