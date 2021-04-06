using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using Rollers.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Controllers
{
	[Route("[controller]")]
	public class LocationsController : Controller
	{

		private readonly IRollerSkateMapLocationRepository _locationRepository = null;


		public LocationsController(IRollerSkateMapLocationRepository locationRepository)
		{
			_locationRepository = locationRepository;
		}

		[Route("")]
		public IActionResult Locations(int page = 1)
		{
			ViewBag.Current = "Locations";

			LocationsViewModel locationsViewModel = new LocationsViewModel
			{
				RollerSkateMapLocations = _locationRepository.GetAllRollerSkateMapLocations().OrderBy(d => d.CreatedDateTime).ToList(),
				RollerSkateMapLocationPerPage = 2,
				CurrentPage = page
			};

			return View(locationsViewModel);
		}

		[Route("{locationId}")]
		public IActionResult Location(int locationId)
		{

			var locationVeiwModel = new LocationViewModel
			{
				RollerSkateMapLocation = _locationRepository.GetRollerSkateMapLocation(locationId)
			};

			return View(locationVeiwModel);
		}

		[HttpPost]
		[Route("AddLocationPartial")]
		public async Task<IActionResult> AddLocationPartial([FromBody] RollerSkateMapLocationViewModel model)
        {
			if (ModelState.IsValid)
            {
				RollerSkateMapLocation rollerSkateMapLocation = _locationRepository.GetAllRollerSkateMapLocations().FirstOrDefault(l => l.LocationName == model.LocationName);
				if (rollerSkateMapLocation == null)
                {
					RollerSkateMapLocation newRollerSkateMapLocation = new RollerSkateMapLocation
					{
						Longitude = model.Longitude,
						Latitude = model.Latitude,
						LocationName = model.LocationName,
						Address = model.Address,
						CreatedDateTime = model.CreatedDateTime,
						Description = model.Description
					};

					_locationRepository.AddRollerSkateMapLocation(newRollerSkateMapLocation);

					return Json("ok");
                }
				else
				{
					ModelState.AddModelError("", "Such location already exists");
				}
			}
			return Ok();
           
        }


	}
}