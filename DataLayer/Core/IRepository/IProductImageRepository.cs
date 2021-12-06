using System.Threading.Tasks;
using CustomModel;
using DataLayer.Model;
using Microsoft.AspNetCore.Http;

namespace DataLayer.Core.IRepository
{
    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {
        Task<bool> ImageUpload(ImageUploadCustomModel model);
    }
}