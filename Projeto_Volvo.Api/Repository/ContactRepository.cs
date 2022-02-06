using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class ContactRepository : IContactRepository
    {
        private VolvoContext context;
        private bool disposed = false;

        public ContactRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<Contact> AddEntity(Contact entity)
        {
            await context.Set<Contact>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Contact>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Contact>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<ICollection<Contact>> GetAllEntity()
        {
            var entities = await context.Set<Contact>().ToListAsync<Contact>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Contact> GetOneEntity(int id)
        {
            var entity = await context.Set<Contact>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<Contact> UpdateEntity(int id, Contact entity)
        {
            var oldEntity = await context.Set<Contact>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Contact>(oldEntity).CurrentValues.SetValues(entity);
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