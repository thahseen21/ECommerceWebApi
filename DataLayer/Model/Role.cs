using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Model
{
    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            RoleClaims = new HashSet<RoleClaim>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public string ConcurrencyStamp { get; set; }
        [StringLength(30)]
        public string NormalizedName { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty(nameof(RoleClaim.Role))]
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
