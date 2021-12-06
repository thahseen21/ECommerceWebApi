using DataLayer.Core.IRepository;

namespace DataLayer.Core.Configuration
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        ICategoryHistoryRepository CategoryHistory { get; }

        IProductRepository Product { get; }
        
        IProductHistoryRepository ProductHistory { get; }

        IProductImageRepository ProductImage { get; }

    }
}