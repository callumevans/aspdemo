using AspBehaviour.Interfaces;
using AspBehaviour.Models;

namespace AspBehaviour.Services
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