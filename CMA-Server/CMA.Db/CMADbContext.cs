using CMA.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CMA.Db
{
    public class CMADbContext : DbContext
    {
        public CMADbContext(DbContextOptions<CMADbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
