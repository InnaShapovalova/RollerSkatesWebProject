using Rollers.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.ViewModels
{
    public class RollerSkatesListViewModel
    {
        public IEnumerable<RollerSkate> allRollerSkates { get; set; }

        public string rollerSkateCategory { get; set; }
    }
}
