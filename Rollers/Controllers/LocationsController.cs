using Microsoft.AspNetCore.Mvc;
using PagedList;
using Rollers.Domain.Abstractions;
using Rollers.Domain.Models;
using Rollers.ViewModels;
using System.Linq;

namespace Rollers.Controllers {
	[Route("[controller]")]
	public class LocationsController : Controller {
		
		private readonly IRollerSkateMapLocationRepository _locationRepository = null;
		

		public LocationsController(IRollerSkateMapLocationRepository locationRepository) {
			_locationRepository = locationRepository;
		}
		
		[Route("")]
		public IActionResult Locations(int page = 1) {
			ViewBag.Current = "Locations";

			LocationsViewModel locationsViewModel = new LocationsViewModel {
				RollerSkateMapLocations = _locationRepository.GetAllRollerSkateMapLocations().OrderBy(d => d.CreatedDateTime).ToList(),
				RollerSkateMapLocationPerPage = 2,
				CurrentPage = page
			};

			return View(locationsViewModel);
		}

		[Route("{locationId}")]
		public IActionResult Location(int locationId) {

			var locationVeiwModel = new LocationViewModel {
				rollerSkateMapLocation = _locationRepository.GetRollerSkateMapLocation(locationId)
			};

			return View(locationVeiwModel);
		}
		
	}
}