using CMA.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMA.Repository.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        IEnumerable<Contact> GetContacts(int pageIndex, int pageSize);
    }
}
