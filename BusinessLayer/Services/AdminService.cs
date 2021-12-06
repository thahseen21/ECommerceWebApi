using System.Threading.Tasks;
using BusinessLayer.IServices;
using DataLayer.Core.Configuration;
using DataLayer.Model;
using Mapster;
using CustomModel;

namespace BusinessLayer.Services
{
    public class AdminService : IAdminServices
    {

        private readonly IUnitOfWork _uow;

        public AdminService(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<bool> AddCategory(CategoryCustomModel model)
        {
            try
            {
                var entity = new Category();
                entity = model.Adapt<Category>();
                entity.IsActive = true;
                await this._uow.Category.Add(entity);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public bool EditCategory(EditCategoryCustomModel model)
        {
            try
            {
                var entity = new Category();
                entity = model.Adapt<Category>();

                this._uow.Category.Upsert(entity);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddProduct(ProductCustomModel model)
        {
            try
            {
                var entity = new Product();
                entity = model.Adapt<Product>();
                await this._uow.Product.Add(entity);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool EditProduct(EditProductCustomModel model)
        {
            try
            {
                var entity = new Product();
                entity = model.Adapt<Product>();

                this._uow.Product.Upsert(entity);
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> UploadImage(ImageUploadCustomModel model)
        {
            await this._uow.ProductImage.ImageUpload(model);
            return true;
        }
    }
}