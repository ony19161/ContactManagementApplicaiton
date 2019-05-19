using System;
using System.Collections.Generic;
using System.Text;

namespace CMA.DTO.RequestModels
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        public string CategoryId { get; set; }
    }
}
