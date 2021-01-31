using RollerSkatesWebProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string email, string password);

    }
}
