using System;
using System.Collections.Generic;
using System.Text;

namespace CMA.DTO.RequestModels
{
    public class Category : BaseEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
