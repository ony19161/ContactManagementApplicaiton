using CMA.Db;
using CMA.Db.Models;
using CMA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMA.Repository.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        private readonly CMADbContext _dbContext;

        public ContactRepository(CMADbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Contact> GetContacts(int pageIndex, int pageSize)
        {
            return _dbContext.Contacts;
        }
    }
}
