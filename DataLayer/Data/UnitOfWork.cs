using System.Threading.Tasks;
using DataLayer.Core.Configuration;
using DataLayer.Core.IRepository;
using DataLayer.Core.Repository;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        public ICategoryRepository Category { get; private set; }

        public ICategoryHistoryRepository CategoryHistory { get; private set; }

        public IProductRepository Product { get; private set; }

        public IProductHistoryRepository ProductHistory { get; private set; }

        public IProductImageRepository ProductImage { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext, IConfiguration config)
        {
            this._dbContext = dbContext;

            this.Category = new CategoryRepository(dbContext);
            this.CategoryHistory = new CategoryHistoryRepository(dbContext);
            this.Product = new ProductRepository(dbContext);
            this.ProductHistory = new ProductHistoryRepository(dbContext);
            this.ProductImage = new ProductImageRepository(dbContext, config);
        }

        public async Task CompleteAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }
    }
}