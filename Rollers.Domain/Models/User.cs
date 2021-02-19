﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Domain.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Login { get; set; }
        public  string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get; set; }
        public List<RollerSkateMapLocation> RollerSkateMapLocations { get; set; }
    }
}
