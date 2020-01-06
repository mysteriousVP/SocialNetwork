using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> context;

        public Repository(DbContext dbContext)
        {
            context = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            context.Add(entity);
        }

        public async Task<T> Get(int id)
        {
            return await context.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.ToListAsync();
        }

        public void Remove(T entity)
        {
            context.Remove(entity);
        }
    }
}
