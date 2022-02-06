using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class BuyerRepository : IBuyerRepository
    {
        private VolvoContext context;
        private bool disposed = false;

        public BuyerRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<Buyer> AddEntity(Buyer entity)
        {
            await context.Set<Buyer>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Buyer>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Buyer>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<ICollection<Buyer>> GetAllEntity()
        {
            var entities = await context.Set<Buyer>().ToListAsync<Buyer>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Buyer> GetOneEntity(int id)
        {
            var entity = await context.Set<Buyer>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<Buyer> UpdateEntity(int id, Buyer entity)
        {
            var oldEntity = await context.Set<Buyer>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Buyer>(oldEntity).CurrentValues.SetValues(entity);
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