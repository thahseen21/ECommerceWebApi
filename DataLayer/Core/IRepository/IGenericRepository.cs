using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);

        bool Upsert(T entity);

        Task<bool> Delete(T entity);

        Task<List<T>> FetchAll();
    }
}