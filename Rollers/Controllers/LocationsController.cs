using Microsoft.AspNetCore.Mvc;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using Rollers.ViewModels;

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
		public IActionResult Locations()
		{
			ViewBag.Current = "Locations";

			LocationsViewModel locationsViewModel = new LocationsViewModel
			{
				RollerSkateMapLocations = _locationRepository.GetAllRollerSkateMapLocations()
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

	}
}