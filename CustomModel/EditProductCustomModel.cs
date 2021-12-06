using System;

namespace CustomModel
{
    public class EditProductCustomModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public DateTime ExpiryOn { get; set; }

        public int Stock { get; set; }

        public bool? IsActive { get; set; }

    }
}