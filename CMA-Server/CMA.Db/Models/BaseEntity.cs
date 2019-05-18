using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMA.Db.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        [Required]
        public DateTime ModifiedAt { get; set; }

        [MaxLength(20)]
        public string RequestFrom { get; set; }
    }
}
