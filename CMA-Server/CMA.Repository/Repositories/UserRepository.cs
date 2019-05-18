using CMA.Db;
using CMA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMA.Repository.Repositories
{
    public class UserRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CMADbContext _context;

        public UserRepository(CMADbContext context)
        {
            _context = context;
        }
        public Task<bool> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
