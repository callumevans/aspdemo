using AspBehaviour.Models;

namespace AspBehaviour.Interfaces
{
    public interface ICreateUserRequestMapper
    {
        User MapToUser(CreateUser createUser);
    }
}