using System;
using System.Collections.Generic;
using System.Linq;
using Rollers.Domain.Models;

namespace Rollers.ViewModels
{
	public class LocationsViewModel
	{
        public List<RollerSkateMapLocation> RollerSkateMapLocations { get; set; }
        public int RollerSkateMapLocationPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(RollerSkateMapLocations.Count / (double)RollerSkateMapLocationPerPage));
        }
        public IEnumerable<RollerSkateMapLocation> PaginatedRollerSkateMapLocations()
        {
            int start = (CurrentPage - 1) * RollerSkateMapLocationPerPage;
            return RollerSkateMapLocations.OrderBy(b => b.Id).Skip(start).Take(RollerSkateMapLocationPerPage);
        }
    }
}