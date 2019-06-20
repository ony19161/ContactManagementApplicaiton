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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
