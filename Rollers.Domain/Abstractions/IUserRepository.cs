using Rollers.Domain.Models;
using System.Collections.Generic;

namespace Rollers.Domain.Abstractions
{
    public interface IUserRepository
    {
        User GetUser(int id);
        int AddUser(User newUser);
        List<User> GetAllUsers();
        void DeleteUser(int id);
        User UpdateUser(User updatedUser);
    }
}
