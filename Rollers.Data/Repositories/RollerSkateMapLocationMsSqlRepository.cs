using Rollers.Data.Contexts;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Rollers.Data.Repositories
{
    public class RollerSkateMapLocationMsSqlRepository : IRollerSkateMapLocationRepository
    {
        private readonly AppDbContext _appDbContext = null;
        public RollerSkateMapLocationMsSqlRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void DeleteRollerSkateMapLocation(int id)
        {
            var rollerSkateMapLocation = _appDbContext.RollerSkateMapLocations.FirstOrDefault(p => p.Id == id);
            if (rollerSkateMapLocation != null)
            {
                _appDbContext.RollerSkateMapLocations.Remove(rollerSkateMapLocation);
                _appDbContext.SaveChanges();
            }
        }

        public List<RollerSkateMapLocation> GetAllRollerSkateMapLocations()
        {
            return _appDbContext.RollerSkateMapLocations
                             .Include("Comments")
                             .Include("User")
                             .ToList();
        }

        public RollerSkateMapLocation GetRollerSkateMapLocation(int id)
        {
            return _appDbContext.RollerSkateMapLocations
                             .Include("Comments")
                             .Include("User")
                             .First(x => x.Id == id);
        }

        public void AddRollerSkateMapLocation(RollerSkateMapLocation newRollerSkateMapLocation)
        {
            _appDbContext.RollerSkateMapLocations.Add(newRollerSkateMapLocation);
            _appDbContext.SaveChanges();
        }

        public void UpdateRollerSkateMapLocation(RollerSkateMapLocation updatedRollerSkateMapLocation)
        {
            RollerSkateMapLocation location = _appDbContext.RollerSkateMapLocations.FirstOrDefault(x => x.Id == updatedRollerSkateMapLocation.Id);

            if (location != null)
            {
                location = updatedRollerSkateMapLocation;
                _appDbContext.SaveChanges();
            }
        }
    }
}
