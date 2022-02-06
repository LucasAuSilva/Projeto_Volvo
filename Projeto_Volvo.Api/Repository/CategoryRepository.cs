using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private VolvoContext context;
        private bool disposed = false;

        public CategoryRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<Category> AddEntity(Category entity)
        {
            await context.Set<Category>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<Category>().FindAsync(id);
            if (entity != null)
            {
                context.Set<Category>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<ICollection<Category>> GetAllEntity()
        {
            var entities = await context.Set<Category>().ToListAsync<Category>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<Category> GetOneEntity(int id)
        {
            var entity = await context.Set<Category>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<Category> UpdateEntity(int id, Category entity)
        {
            var oldEntity = await context.Set<Category>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<Category>(oldEntity).CurrentValues.SetValues(entity);
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