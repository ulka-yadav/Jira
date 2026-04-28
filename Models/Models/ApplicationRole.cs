using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class ApplicationRole:IdentityRole
    {
        [DataType(DataType.Date)] //Only Date
        [Required]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)] //Only Date
        [Required]
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;

        public int CreatedByUserId { get; set; }
        public ApplicationUser CreatedByUser { get; set; }

        public int ModifiedUserId { get; set; }
        public ApplicationUser ModifiedByUser { get; set; }
    }
}
