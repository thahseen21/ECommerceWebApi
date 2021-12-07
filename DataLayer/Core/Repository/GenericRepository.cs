using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Core.IRepository;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext dbContext;

        protected DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<T>> FetchAll()
        {
            return await dbSet.ToListAsync();
        }

        public bool Upsert(T entity)
        {
            try
            {
                var isEntity = this.dbSet.Update(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}