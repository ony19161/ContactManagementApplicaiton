using System;
using System.Collections.Generic;
using System.Text;

namespace CMA.Models.Core
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
