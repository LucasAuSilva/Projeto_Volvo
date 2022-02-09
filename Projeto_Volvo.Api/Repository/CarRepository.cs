using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;

namespace Projeto_Volvo.Api.Repository
{
    public class CarRepository : ICarRepository
    {
        private VolvoContext context;
        private bool disposed = false;

        public CarRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Car>> GetCarsPerKmAndSystemVersion(int km, string versionSystem)
        {
            var cars = await context.Cars
                .Where(c => c.Kilometrage >= km)
                .Where(c => c.VersionSystem == versionSystem)
                .ToListAsync();

            return cars;
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

            throw new EntityException("Carro não encontrado.");
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
            var entity = await context.Set<Car>()
                .Include("Owner")
                .SingleAsync(c => c.IdCar == id);

            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Carro não encontrado.");
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

            throw new EntityException("Carro não encontrado.");
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