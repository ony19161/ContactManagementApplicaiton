using System;
using System.Collections.Generic;
using System.Text;

namespace CMA.DTO.RequestModels
{
    public class UserFilter
    {
        public string SearchText { get; set; }
        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize = 10; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
        public string SortBy { get; set; }
        public bool IsIdValue { get; set; }
    }
}
