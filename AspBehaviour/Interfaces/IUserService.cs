using System.Collections.Generic;
using System.Threading.Tasks;
using AspBehaviour.Models;

namespace AspBehaviour.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task<User> CreateUser(User user);
    }
}