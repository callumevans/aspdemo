using Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
    }
}