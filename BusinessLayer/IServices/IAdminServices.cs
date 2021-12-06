using System.Threading.Tasks;
using DataLayer.Model;
using CustomModel;

namespace BusinessLayer.IServices
{
    public interface IAdminServices
    {
        public Task<bool> AddCategory(CategoryCustomModel model);

        public bool EditCategory(EditCategoryCustomModel model);

        public Task<bool> AddProduct(ProductCustomModel model);

        bool EditProduct(EditProductCustomModel model);

        Task<bool> UploadImage(ImageUploadCustomModel model);
    }
}