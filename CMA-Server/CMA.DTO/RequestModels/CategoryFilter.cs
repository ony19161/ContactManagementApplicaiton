using System;
using System.Collections.Generic;
using System.Text;

namespace CMA.DTO.RequestModels
{
    public class CategoryFilter
    {
        public string SearchText { get; set; }
        public PagingFilter PagingFilter { get; set; }
        public string SortBy { get; set; }
    }
}
