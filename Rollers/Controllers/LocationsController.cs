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
		private readonly IUserRepository _userRepository = null;

		public LocationsController(IRollerSkateMapLocationRepository locationRepository, IUserRepository userRepository)
		{
			_locationRepository = locationRepository;
			_userRepository = userRepository;
		}


		[Route("")]
		public IActionResult Locations(int page = 1)
		{
			ViewBag.Current = "Locations";

			LocationsViewModel locationsViewModel = new LocationsViewModel
			{
				RollerSkateMapLocations = _locationRepository.GetAllRollerSkateMapLocations().OrderBy(d => d.LocationCreatedDateTime).ToList(),
				RollerSkateMapLocationPerPage = 5,
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

			foreach(var comment in locationVeiwModel.RollerSkateMapLocation.Comments)
            {
				comment.User = _userRepository.GetUser(comment.UserId ?? -1);
            }

			return View(locationVeiwModel);
		}
	}
}