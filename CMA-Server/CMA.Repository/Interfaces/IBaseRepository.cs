using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMA.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Get(string id);
        Task<List<T>> GetAll();
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(string id);
    }
}
