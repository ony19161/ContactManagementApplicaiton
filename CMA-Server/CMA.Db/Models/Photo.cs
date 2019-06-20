using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMA.Db.Models
{
    public class Photo : BaseEntity
    {
        [Required]
        [MaxLength(400)]
        public string Url { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

    }
}
