using Rollers.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data.interfaces
{
    public interface IAllRollerSkates
    {
        public IEnumerable<RollerSkate> RollerSkates{ get; }
        public IEnumerable<RollerSkate> getFavRollerSkates { get; }
        public RollerSkate getObjectRollerSkate(int rollerId);
    }
}
