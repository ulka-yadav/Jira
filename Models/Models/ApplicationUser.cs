using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        [DataType(DataType.Time)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
