using DataLayer.Core.IRepository;
using DataLayer.Data;
using DataLayer.Model;

namespace DataLayer.Core.Repository
{
    public class CategoryHistoryRepository : GenericRepository<CategoryHistory>, ICategoryHistoryRepository
    {
        public CategoryHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}