using DataLayer.Core.IRepository;
using DataLayer.Data;
using DataLayer.Model;

namespace DataLayer.Core.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext) { }


    }
}