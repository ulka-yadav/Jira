using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel
{
    public class RegisterVM
    {
        public string Name { get; set; }
        [Required]
        [Display(Name ="Username")]
        public string UserName {  get; set; }
        [Required]
         public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage="Password not matched")]
        public string ConfirmPassword { get; set; }




    }
}
