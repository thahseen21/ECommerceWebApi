using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Model
{
    [Table("ProductImage")]
    public partial class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [StringLength(80)]
        public string Image { get; set; }
        public int ProductId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDisplay { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductImages")]
        public virtual Product Product { get; set; }
    }
}
