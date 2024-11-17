using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Model;

namespace WebApi
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // Represents the Users table
    }
}
