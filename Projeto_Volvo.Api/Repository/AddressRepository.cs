using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;

namespace Projeto_Volvo.Api.Repository
{
    public class AddressRepository : IAddressRepository
    {
        protected VolvoContext context;
        private bool disposed = false;

        protected AddressRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<Address> AddEntity(Address entity)
        {
            await context.Set<Address>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Address>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Address>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<ICollection<Address>> GetAllEntity()
        {
            var entities = await context.Set<Address>().ToListAsync<Address>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Address> GetOneEntity(int id)
        {
            var entity = await context.Set<Address>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<Address> UpdateEntity(int id, Address entity)
        {
            var oldEntity = await context.Set<Address>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Address>(oldEntity).CurrentValues.SetValues(entity);
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