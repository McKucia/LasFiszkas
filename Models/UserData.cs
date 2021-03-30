using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LasFiszkas.Models
{
    public class UserData
    {
        [MaxLength(20)]
        public string NickName { get; set; }

        [ScaffoldColumn(false)]
        public byte[] ProfileImageFIle { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail")]
        public string Email { get; set; }
    }
}