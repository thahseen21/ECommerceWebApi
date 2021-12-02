using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Model
{
    [Table("CategoryHistory")]
    public partial class CategoryHistory
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }
        public Guid ModifiedBy { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("CategoryHistories")]
        public virtual Category Category { get; set; }
    }
}
