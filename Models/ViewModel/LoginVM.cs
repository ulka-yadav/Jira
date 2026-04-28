using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel
{
    public class LoginVM
    {
        [Required]
        [Display(Name ="Username")]
        public string UserName {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Remember Me")]
        public bool RememberMe {  get; set; }


    }
}
