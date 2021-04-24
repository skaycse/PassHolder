using Microsoft.EntityFrameworkCore;
using passholder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Context
{
    public class PassDbContext : DbContext
    {
        public PassDbContext(DbContextOptions<PassDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> Userlogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
