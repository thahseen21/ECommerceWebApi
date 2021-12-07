using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomModel;
using BusinessLayer.IServices;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {

        private readonly IService _service;

        public AdminController(IService service)
        {
            this._service = service;
        }

        [HttpGet("fetchcategory")]
        public async Task<IActionResult> FetchCategory()
        {
            try
            {
                var result = await this._service.AdminService.FetchCategory();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("fetchProduct")]
        public IActionResult FetchProduct(int id)
        {
            try
            {
                var result = this._service.AdminService.FetchProduct(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost("addCategory")]
        public async Task<IActionResult> AddCategory(CategoryCustomModel model)
        {
            try
            {
                await this._service.AdminService.AddCategory(model);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }

        }

        [HttpPost("editCategory")]
        public IActionResult EditCategory(EditCategoryCustomModel model)
        {
            try
            {
                this._service.AdminService.EditCategory(model);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct(ProductCustomModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await this._service.AdminService.AddProduct(model);
                    return Ok();
                }
            }
            catch (System.Exception)
            {
            }
            return BadRequest();
        }

        [HttpPost("editProduct")]
        public IActionResult EditProduct(EditProductCustomModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._service.AdminService.EditProduct(model);
                    return Ok();
                }
            }
            catch (System.Exception)
            {
            }
            return BadRequest();
        }

        [HttpPost("uploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadCustomModel model)
        {
            try
            {
                await this._service.AdminService.UploadImage(model);
                return Ok();
            }
            catch (System.Exception)
            {
            }
            return BadRequest();
        }
    }
}