using Asp.Interfaces;
using Asp.Models;

namespace Asp.Services
{
    public class CreateUserRequestMapper : ICreateUserRequestMapper
    {
        public User MapToUser(CreateUser createUser)
        {
            return new User
            {
                Name = createUser.Name
            };
        }
    }
}