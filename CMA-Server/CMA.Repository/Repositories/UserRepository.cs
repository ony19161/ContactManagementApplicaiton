using CMA.Db;
using CMA.Db.Models;
using CMA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMA.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly CMADbContext _dbContext;

        public UserRepository(CMADbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> IsUserExists(string username)
        {
            if (await _dbContext.Users.AnyAsync(u => u.Email.Equals(username)))
                return true;

            return false;
        }

        public async Task UpdateUserLastLoggedIn(User user)
        {
            user.LastLoggedIn = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> Login(string username, string password)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(username));

            if (user == null)
                return null;

            if (!Utility.Cryptography.IsValidPasswordHash(password, user.Password, user.PasswordSalt))
                return null;


            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            Utility.Cryptography.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

    }
}
