using Microsoft.EntityFrameworkCore;
using Rollers.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data
{
    public class AppDBContent: DbContext {

        public AppDBContent(DbContextOptions<AppDBContent> options): base(options)
        {

        }

        public DbSet<RollerSkate> rollerSkates { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
