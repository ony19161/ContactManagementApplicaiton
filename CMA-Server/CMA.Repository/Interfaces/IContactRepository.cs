using CMA.Db.Models;
using CMA.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RequestModels = CMA.DTO.RequestModels;

namespace CMA.Repository.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<PagedList<Contact>> GetContacts(RequestModels.PagingFilter pagingFilter);
        Task<IEnumerable<Contact>> GetContactsToExport();
    }
}
