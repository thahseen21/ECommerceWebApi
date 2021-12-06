using DataLayer.Core.IRepository;
using DataLayer.Data;
using DataLayer.Model;

namespace DataLayer.Core.Repository
{
    public class ProductHistoryRepository : GenericRepository<ProductHistory>, IProductHistoryRepository
    {
        public ProductHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}