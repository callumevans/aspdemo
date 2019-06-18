using Asp.Models;

namespace Asp.Interfaces
{
    public interface ICreateUserRequestMapper
    {
        User MapToUser(CreateUser createUser);
    }
}