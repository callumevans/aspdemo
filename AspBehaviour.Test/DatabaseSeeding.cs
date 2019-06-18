using System.Collections.Generic;
using AspBehaviour.Models;

namespace AspBehaviour.Test
{
    public static class DatabaseSeeding
    {
        public static List<User> Users = new List<User>
        {
            new User
            {
                Name = "First User"
            },
            
            new User
            {
                Name = "Second User"
            }
        };
    }
}