using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;

namespace Projeto_Volvo.Api.Repository
{
    public class AcessoriesCategoryRepository : IAcessoriesCategoryRepository
    {
        private VolvoContext context;
        private bool disposed = false;

        public AcessoriesCategoryRepository(VolvoContext context)
        {
            this.context = context;
        }

        public async Task<AcessoriesCategory> AddEntity(AcessoriesCategory entity)
        {
            await context.Set<AcessoriesCategory>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await context.Set<AcessoriesCategory>().FindAsync(id);
            if (entity != null)
            {
                context.Set<AcessoriesCategory>().Remove(entity);
                await context.SaveChangesAsync();
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<ICollection<AcessoriesCategory>> GetAllEntity()
        {
            var entities = await context.Set<AcessoriesCategory>().ToListAsync<AcessoriesCategory>();
            return entities;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async Task<AcessoriesCategory> GetOneEntity(int id)
        {
            var entity = await context.Set<AcessoriesCategory>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }

            throw new EntityException("Entidade não encontrada.");
        }

        public async Task<AcessoriesCategory> UpdateEntity(int id, AcessoriesCategory entity)
        {
            var oldEntity = await context.Set<AcessoriesCategory>().FindAsync(id);
            if (oldEntity != null)
            {
                context.Entry<AcessoriesCategory>(oldEntity).CurrentValues.SetValues(entity);
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