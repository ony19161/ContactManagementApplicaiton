using CMA.Db;
using CMA.Db.Models;
using CMA.Repository.Interfaces;
using CMA.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestModels = CMA.DTO.RequestModels;

namespace CMA.Repository.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        private readonly CMADbContext _dbContext;

        public ContactRepository(CMADbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PagedList<Contact>> GetContacts(RequestModels.PagingFilter pagingFilter)
        {
            var contacts = _dbContext.Contacts.Include(c => c.Photo).Include(c => c.Category).OrderBy(c => c.Name);

            return await PagedList<Contact>.CreateAsync(contacts, pagingFilter.PageIndex, pagingFilter.PageSize);
        }

        public async Task<IEnumerable<Contact>> GetContactsToExport()
        {
            return await _dbContext.Contacts.Include(c => c.Category).ToListAsync();
        }
    }
}
