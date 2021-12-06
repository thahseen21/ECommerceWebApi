using Microsoft.AspNetCore.Http;

namespace CustomModel
{
    public class ImageUploadCustomModel
    {
        public IFormFile File { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public int ProductId { get; set; }


    }
}