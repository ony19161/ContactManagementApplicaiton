using CMA.Models.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace CMA.Data
{
    public class CMADbContext : DbContext
    {
        public CMADbContext(DbContextOptions<CMADbContext> options) : base(options)
        {

        }

        public DbSet<User> Users{ get; set; }
    }
}
