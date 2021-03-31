using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LasFiszkas.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Podaj prawidłowy adres email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wprowadź hasło")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class RegisterVM
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Pole Nick jest wymagane")]
        public string NickName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać przynajmniej 6 znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        public string ConfirmPassword { get; set; }

        [ScaffoldColumn(false)]
        public byte[] ProfileImageFIle { get; set; }
    }
}