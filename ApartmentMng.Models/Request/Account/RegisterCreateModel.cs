using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApartmentMng.Models.Request.Account
{
    public class RegisterCreateModel
    {
        [Required(ErrorMessage = "Lütfen Alanı Doldurun")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Alanı Doldurun")]
        [EmailAddress(ErrorMessage = "Email adres formatında olması gerekiyor")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Alanı Doldurun")]
        [StringLength(100, ErrorMessage = "Minumum 6 karakter olmak zorunda", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        public string NameSurname { get; set; }
        public string Job { get; set; }
        public string PhoneNumber { get; set; }

    }
}
