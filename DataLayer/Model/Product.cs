using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Model
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Discounts = new HashSet<Discount>();
            ProductHistories = new HashSet<ProductHistory>();
            ProductImages = new HashSet<ProductImage>();
        }

        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(120)]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExpiryOn { get; set; }
        public int Stock { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [InverseProperty(nameof(Discount.Product))]
        public virtual ICollection<Discount> Discounts { get; set; }
        [InverseProperty(nameof(ProductHistory.Product))]
        public virtual ICollection<ProductHistory> ProductHistories { get; set; }
        [InverseProperty(nameof(ProductImage.Product))]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
