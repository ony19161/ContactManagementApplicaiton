using CMA.Db.Models;
using CMA.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RequestModels = CMA.DTO.RequestModels;

namespace CMA.Repository.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task Update(Category entity);
        Task<PagedList<Category>> GetCategories(RequestModels.CategoryFilter categoryFilter);
    }
}
