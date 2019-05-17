﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMA.Models.Core
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
    }
}
