using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMA.Db.Models
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        /*Hashed Password*/
        public byte[] Password { get; set; }

        [Required]
        /*Password Salt*/
        public byte[] PasswordSalt { get; set; }

        public DateTime? LastLoggedIn { get; set; }

    }
}
