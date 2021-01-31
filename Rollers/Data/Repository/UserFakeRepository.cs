using Rollers.Data.Interfaces;
using RollerSkatesWebProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data.Repository
{
    public class UserFakeRepository : IUserRepository
    {
        private List<User> UserList => new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName = "Roman",
                LastName = "Chubak",
                Password = "fvd",
                Login = "vds",
                Email = "fd",
                UserType = UserTypeEnum.Admin
            },
            new User()
            {
                Id = 1,
                FirstName = "Roman",
                LastName = "Chubak",
                Password = "fvd1",
                Login = "vds",
                Email = "fd@gmail",
                UserType = UserTypeEnum.Visitor
            }
        };
        public User GetUser(string email, string password)
        {
            return UserList.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
