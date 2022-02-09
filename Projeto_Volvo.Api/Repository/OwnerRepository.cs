using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private VolvoContext context;
        private bool disposed = false;

        public OwnerRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<Owner> AddEntity(Owner entity)
        {
            await context.Set<Owner>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Owner>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Owner>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Proprietario não encontrada.");
        }

        public async Task<ICollection<Owner>> GetAllEntity()
        {
            var entities = await context.Set<Owner>().ToListAsync<Owner>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Owner> GetOneEntity(int id)
        {
            var entity = await context.Set<Owner>()
                .Include("Address")
                .Include("Contact")
                .SingleAsync(o => o.IdOwner == id);

            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Proprietario não encontrada.");
        }

        public async Task<Owner> UpdateEntity(int id, Owner entity)
        {
            var oldEntity = await context.Set<Owner>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Owner>(oldEntity).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            throw new EntityException("Proprietario não encontrada.");
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