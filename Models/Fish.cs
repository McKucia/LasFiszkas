using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LasFiszkas.Models
{
    public class Fish
    {
        [Key]
        public int FishId { get; set; }
        public int SetId { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public string EspContent { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public string PlContent { get; set; }

        public virtual Set Set { get; set; }
    }
}