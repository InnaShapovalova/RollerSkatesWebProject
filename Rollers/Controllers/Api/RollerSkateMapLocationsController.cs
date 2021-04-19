using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using Rollers.ViewModels;
using System;

namespace Rollers.Controllers.Api
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RollerSkateMapLocationsController: Controller
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
        public IActionResult AddRollerSkateMapLocation([FromBody] RollerSkateMapLocationViewModel newRollerSkateMapLocationViewModel)
        {
            if(newRollerSkateMapLocationViewModel.UserId < 1)
            {
                return BadRequest();
            }
            RollerSkateMapLocation rollerSkateMapLocation = new RollerSkateMapLocation()
            {
                UserId = newRollerSkateMapLocationViewModel.UserId,
                LocationName = newRollerSkateMapLocationViewModel.LocationName,
                Longitude = newRollerSkateMapLocationViewModel.Longitude,
                Latitude = newRollerSkateMapLocationViewModel.Latitude,
                LocationCreatedDateTime = DateTime.Now,
                Address = newRollerSkateMapLocationViewModel.Address,
                Description = newRollerSkateMapLocationViewModel.Description
            };
            _rollerSkateMapLocationRepository.AddRollerSkateMapLocation(rollerSkateMapLocation);
            return Json("Ok");
        }
        [Route("rollerskatemaplocation/{id}")]
        [HttpGet]
        public IActionResult GetRollerSkateMapLocationById(int id)
        {
            return Ok(_rollerSkateMapLocationRepository.GetRollerSkateMapLocation(id));
        }
        [Route("rollerskatemaplocation/update")]
        [HttpPost]
        public IActionResult UpdateRollerSkateMapLocation([FromBody] RollerSkateMapLocation updatedRollerSkateMapLocation)
        {
            _rollerSkateMapLocationRepository.UpdateRollerSkateMapLocation(updatedRollerSkateMapLocation);
            return Ok();
        }

        [Route("rollerskatemaplocation/delete/{id}")]
        [HttpPost]
        public IActionResult DeleteRollerSkateMapLocation(int id)
        {
            _rollerSkateMapLocationRepository.DeleteRollerSkateMapLocation(id);
            return Json("Ok");
        }

    }
}

