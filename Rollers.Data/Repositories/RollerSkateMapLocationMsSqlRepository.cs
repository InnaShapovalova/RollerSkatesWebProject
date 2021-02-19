using Rollers.Data.Contexts;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            _appDbContext.RollerSkateMapLocations.Remove(rollerSkateMapLocation);
            _appDbContext.SaveChanges();
        }

        public List<RollerSkateMapLocation> GetAllRollerSkateMapLocations()
        {
            return _appDbContext.RollerSkateMapLocations.ToList();
        }

        public RollerSkateMapLocation GetRollerSkateMapLocation(int id)
        {
            return _appDbContext.RollerSkateMapLocations.First(x => x.Id == id);
        }
        
        public void AddRollerSkateMapLocation(RollerSkateMapLocation newRollerSkateMapLocation)
        {
            _appDbContext.RollerSkateMapLocations.Add(newRollerSkateMapLocation);
        }

        public RollerSkateMapLocation UpdateRollerSkateMapLocation(RollerSkateMapLocation updatedRollerSkateMapLocation)
        {
            return _appDbContext.RollerSkateMapLocations.Where(p => p.Id == updatedRollerSkateMapLocation.Id).FirstOrDefault();
        }
    }
}
