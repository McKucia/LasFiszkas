using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LasFiszkas.Models
{
    public class Set
    {
        [Key]
        [ScaffoldColumn(false)]
        public int SetId { get; set; }

        [ScaffoldColumn(false)]
        public string UserId { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public string Name { get; set; }

        [StringLength(60)]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public byte[] ImageFIle { get; set; }

        public virtual ICollection<Fish> Fishes { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}