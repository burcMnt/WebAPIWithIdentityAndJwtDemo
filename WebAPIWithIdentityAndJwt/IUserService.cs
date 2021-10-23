using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithIdentityAndJwt
{
    public interface IUserService
    {
        User Authenticate(string email, string passwrd);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _user;
        public UserService()
        {
            _user = new List<User>
            {
                new User
                {
                Id = 1,
                Email = "a@a.com",
                Password = "1"
                }

            };
        }

        public User Authenticate(string email, string passwrd)
        {
            return _user.FirstOrDefault(x => x.Email == email && x.Password == passwrd);
        }
    }
}
