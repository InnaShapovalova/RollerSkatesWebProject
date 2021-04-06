using Rollers.Data.Contexts;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rollers.Data.Repositories
{
    public class UserMsSqlRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext = null;
        public UserMsSqlRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int AddUser(User newUser)
        {
            int id = _appDbContext.Users.Add(newUser).Entity.Id;
            _appDbContext.SaveChanges();

            return id;
        }
        

        public void DeleteUser(int id)
        {
            var user = _appDbContext.Users.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {
                _appDbContext.Remove(user);
                _appDbContext.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            return _appDbContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _appDbContext.Users.First(x => x.Id == id);
        }

        public User UpdateUser(User updatedUser)
        {
            _appDbContext.Entry( _appDbContext.Users.FirstOrDefault(x => x.Id == updatedUser.Id)).CurrentValues.SetValues(updatedUser);
            _appDbContext.SaveChanges();
            return updatedUser;         //It's wrong
        }
    }
}
