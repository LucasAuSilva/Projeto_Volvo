using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;

namespace Projeto_Volvo.Api.Repository
{
    public class CarRepository : ICarRepository
    {
        protected VolvoContext context;
        private bool disposed = false;

        protected CarRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<Car> AddEntity(Car entity)
        {
            await context.Set<Car>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Car>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Car>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<ICollection<Car>> GetAllEntity()
        {
            var entities = await context.Set<Car>().ToListAsync<Car>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Car> GetOneEntity(int id)
        {
            var entity = await context.Set<Car>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<Car> UpdateEntity(int id, Car entity)
        {
            var oldEntity = await context.Set<Car>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Car>(oldEntity).CurrentValues.SetValues(entity);
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