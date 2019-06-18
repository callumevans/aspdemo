using AspBehaviour.Models;
using Microsoft.EntityFrameworkCore;
using AspBehaviour.Models;

namespace AspBehaviour
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
    }
}