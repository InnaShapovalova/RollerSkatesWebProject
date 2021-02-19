﻿using Rollers.Data.Contexts;
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
        public void AddUser(User newUser)
        {
            _appDbContext.Users.Add(newUser);
            _appDbContext.SaveChanges();
        }
        

        public void DeleteUser(int id)
        {
            var user = _appDbContext.Users.FirstOrDefault(p => p.Id == id);
            _appDbContext.Remove(user);
            _appDbContext.SaveChanges();
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
            return _appDbContext.Users.Where(p => p.Id == updatedUser.Id).FirstOrDefault();
        }
    }
}
