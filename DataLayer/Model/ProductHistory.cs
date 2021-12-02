using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Model
{
    [Table("ProductHistory")]
    public partial class ProductHistory
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }
        public Guid ModifiedBy { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductHistories")]
        public virtual Product Product { get; set; }
    }
}
