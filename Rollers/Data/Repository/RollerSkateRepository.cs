using Microsoft.EntityFrameworkCore;
using Rollers.Data.interfaces;
using Rollers.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data.Repository
{
    public class RollerSkateRepository : IAllRollerSkates
    {
        public readonly AppDBContent appDBContent;

        public RollerSkateRepository(AppDBContent appDBContent){
            this.appDBContent = appDBContent;
        }
        public IEnumerable<RollerSkate> RollerSkates => appDBContent.rollerSkates.Include(c => c.Category);

        public IEnumerable<RollerSkate> getFavRollerSkates => appDBContent.rollerSkates.Where(p => p.isFavourite).Include(c => c.Category);

        public RollerSkate getObjectRollerSkate(int rollerId) => appDBContent.rollerSkates.FirstOrDefault(p => p.id == rollerId);
    }
}
