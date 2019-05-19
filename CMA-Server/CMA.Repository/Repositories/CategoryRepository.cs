using CMA.Db;
using CMA.Db.Models;
using RequestModels = CMA.DTO.RequestModels;
using CMA.Repository.Interfaces;
using CMA.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMA.Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly CMADbContext _dbContext;

        public CategoryRepository(CMADbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<Category>> GetCategories(RequestModels.PagingFilter pagingFilter)
        {
            var categories = _dbContext.Categories.OrderBy(c => c.Title);

            return await PagedList<Category>.CreateAsync(categories, pagingFilter.PageIndex, pagingFilter.PageSize);
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }


    }
}
