using Microsoft.EntityFrameworkCore;
using Projeto_Curso_Volvo.Api.Models;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;

namespace Projeto_Volvo.Api.Repository
{
    public abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : class
    {
        internal VolvoContext context;
        private bool disposed = false;

        protected BaseRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<T> AddEntity(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityNotFoundException("Entidade não encontrada.");
        }

        public async Task<ICollection<T>> GetAllEntity()
        {
            var entities = await context.Set<T>().ToListAsync<T>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<T> GetOneEntity(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }

            throw new EntityNotFoundException("Entidade não encontrada.");
        }

        public async Task<T> UpdateEntity(int id, T entity)
        {
            var oldEntity = await context.Set<T>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<T>(oldEntity).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            throw new EntityNotFoundException("Entidade não encontrada.");
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
