using System.Collections.Generic;
using System.Threading.Tasks;
using AspBehaviour.Models;
using AspBehaviour.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspBehaviour.Services
{
    public class UserService : IUserService
    {
        private readonly UsersDbContext usersDbContext;

        public UserService(UsersDbContext usersDbContext)
        {
            this.usersDbContext = usersDbContext;
        }
        
        public Task<List<User>> GetUsers()
        {
            return usersDbContext.Users.ToListAsync();
        }

        public async Task<User> CreateUser(User user)
        {
            usersDbContext.Add(user);
            await usersDbContext.SaveChangesAsync();

            return user;
        }
    }
}