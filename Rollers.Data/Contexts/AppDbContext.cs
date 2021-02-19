using Microsoft.EntityFrameworkCore;
using Rollers.Domain.Models;

namespace Rollers.Data.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users{ get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RollerSkateMapLocation> RollerSkateMapLocations { get; set; }

    }
}
