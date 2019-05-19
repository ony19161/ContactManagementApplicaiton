using System;
using System.Collections.Generic;
using System.Text;

namespace CMA.DTO.ViewModels
{
    public class Pagination
    {
        public Pagination(int pageIndex, int pageSize, int totalCount, int totalPageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.TotalPages = totalPageSize;
        }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
