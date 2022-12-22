using LeavManagemnt_.NET6.Contracts;
using LeavManagemnt_.NET6.Data;
using Microsoft.EntityFrameworkCore;

namespace LeavManagemnt_.NET6.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        ApplicationDbContext context;
        public GenericRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var entities = await context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T?> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var entity = await context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            //context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
