using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public List<Product> FetchProductById(int id)
        {
            return this.dbSet.Where(item => item.CategoryId == id).ToList();
        }
    }
}