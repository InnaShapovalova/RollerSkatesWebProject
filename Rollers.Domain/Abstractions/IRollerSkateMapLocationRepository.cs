using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rollers.Domain.Abstractions
{
    public interface IRollerSkateMapLocationRepository
    {
        RollerSkateMapLocation GetRollerSkateMapLocation(int id);
        void AddRollerSkateMapLocation(RollerSkateMapLocation newRollerSkateMapLocation);
        List<RollerSkateMapLocation> GetAllRollerSkateMapLocations();
        void DeleteRollerSkateMapLocation(int id);
        void UpdateRollerSkateMapLocation(RollerSkateMapLocation updatedRollerSkateMapLocation);
    }
}
