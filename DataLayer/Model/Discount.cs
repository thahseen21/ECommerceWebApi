using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Model
{
    [Table("Discount")]
    public partial class Discount
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte Precentage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ValidTill { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Discounts")]
        public virtual Product Product { get; set; }
    }
}
