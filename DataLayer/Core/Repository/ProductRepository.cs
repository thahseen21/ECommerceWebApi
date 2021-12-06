using DataLayer.Core.IRepository;
using DataLayer.Data;
using DataLayer.Model;

namespace DataLayer.Core.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}