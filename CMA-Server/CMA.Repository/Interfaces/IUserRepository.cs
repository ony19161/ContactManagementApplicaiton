using CMA.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMA.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> IsUserExists(string username);
    }
}
