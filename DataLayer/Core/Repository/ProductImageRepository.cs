using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CustomModel;
using DataLayer.Core.IRepository;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Core.Repository
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
    {
        private readonly IConfiguration _config;

        public ProductImageRepository(ApplicationDbContext dbContext, IConfiguration config) : base(dbContext)
        {
            this._config = config;
        }

        public async Task<bool> ImageUpload(ImageUploadCustomModel model)
        {
            try
            {
                //the path to save the incoming file
                var pathToSave = Path.Combine(this._config["AppSettings:ImagePath"], model.CategoryName + "\\" + model.ProductName);

                //Checking whether the folder exist or else create a folder using the pathToSave variable
                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }
                DirectoryInfo di = new DirectoryInfo(pathToSave);

                var filesCount = di.GetFiles().Count();

                var fileName = "v" + ++filesCount + "_" + model.ProductName + model.File.FileName;

                //the final path where the file would save
                var fullPath = Path.Combine(pathToSave, fileName);

                // creates a stream for a file to read and write 
                var stream = new FileStream(fullPath, FileMode.Create);

                //writing the file to final directory
                await model.File.CopyToAsync(stream);

                stream.Close();

                var entity = new ProductImage();
                entity.Image = model.CategoryName + "\\" + model.ProductName + "\\" + fileName;
                entity.IsActive = true;
                entity.IsDisplay = true;
                entity.ProductId = model.ProductId;

                await Add(entity);
                
                // return Ok();
                return true;

            }
            catch (System.Exception ex)
            {
                // TODO
                return false;
            }
        }
    }
}