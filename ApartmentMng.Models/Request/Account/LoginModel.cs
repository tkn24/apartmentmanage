using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApartmentMng.Models.Request.Account
{
    public class LoginModel
    {
        //email yap!
        [Required(ErrorMessage = "Lütfen Alanı Doldurun")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Alanı Doldurun")]
        [StringLength(100, ErrorMessage = "Minumum 6 karakter olmak zorunda", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
