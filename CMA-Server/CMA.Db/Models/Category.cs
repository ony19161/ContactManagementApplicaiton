using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMA.Db.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
