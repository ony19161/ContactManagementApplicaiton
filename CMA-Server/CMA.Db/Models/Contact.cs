using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMA.Db.Models
{
    public class Contact : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        
        [MaxLength(100)]
        public string City { get; set; }

        
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(13)]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("PhotoId")]
        public virtual Photo Photo { get; set; }
    }
}
