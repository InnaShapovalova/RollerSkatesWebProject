using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollerSkateMapLocationsController: ControllerBase
    {
        private readonly IRollerSkateMapLocationRepository _rollerSkateMapLocationRepository = null;
        public RollerSkateMapLocationsController(IRollerSkateMapLocationRepository rollerSkateMapLocationRepository)
        {
            _rollerSkateMapLocationRepository = rollerSkateMapLocationRepository;
        }
        [Route("")]
        [HttpGet]
        public IActionResult GetAllRollerSkateMapLocations()
        {
            return Ok(_rollerSkateMapLocationRepository.GetAllRollerSkateMapLocations());
        }
        [Route("addrollerskatemaplocation")]
        [HttpPost]
        public IActionResult AddRollerSkateMapLocation([FromBody] RollerSkateMapLocation newRollerSkateMapLocation)
        {
            _rollerSkateMapLocationRepository.AddRollerSkateMapLocation(newRollerSkateMapLocation);
            return Ok();
        }
        [Route("rollerskatemaplocation/{id}")]
        [HttpGet]
        public IActionResult GetRollerSkateMapLocationById(int id)
        {
            return Ok(_rollerSkateMapLocationRepository.GetRollerSkateMapLocation(id));
        }
    }
}

