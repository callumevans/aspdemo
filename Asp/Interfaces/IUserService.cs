using System.Collections.Generic;
using System.Threading.Tasks;
using Asp.Models;

namespace Asp.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task<User> CreateUser(User user);
    }
}