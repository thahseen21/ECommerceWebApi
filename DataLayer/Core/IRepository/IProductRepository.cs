using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Core.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> FetchProductById(int id);
    }
}