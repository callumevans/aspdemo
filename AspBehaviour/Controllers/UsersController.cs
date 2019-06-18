using System.Collections.Generic;
using System.Threading.Tasks;
using AspBehaviour.Interfaces;
using AspBehaviour.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspBehaviour.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ICreateUserRequestMapper createUserRequestMapper;

        public UsersController(IUserService userService, ICreateUserRequestMapper createUserRequestMapper)
        {
            this.userService = userService;
            this.createUserRequestMapper = createUserRequestMapper;
        }
        
        [HttpGet]
        public Task<List<User>> Get()
        {
            return userService.GetUsers();
        }

        [HttpPost]
        public Task<User> Post([FromForm]CreateUser request)
        {
            var userToCreate = createUserRequestMapper.MapToUser(request);
            
            return userService.CreateUser(userToCreate);
        }
    }
}