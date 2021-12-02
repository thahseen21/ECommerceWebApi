using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Model
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            CategoryHistories = new HashSet<CategoryHistory>();
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty(nameof(CategoryHistory.Category))]
        public virtual ICollection<CategoryHistory> CategoryHistories { get; set; }
        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
