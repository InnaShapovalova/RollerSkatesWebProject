﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers
{
    public class AppConfiguration
    {
        public DbSettings DbSettings { get; set; }
    }
    public class DbSettings
    {
        public string MsSqlConnectionString { get; set; }

    }
}
