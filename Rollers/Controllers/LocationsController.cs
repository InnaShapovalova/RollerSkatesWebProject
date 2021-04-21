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
		private readonly AppConfiguration _appConfiguration = null;

		public LocationsController(IRollerSkateMapLocationRepository locationRepository, IUserRepository userRepository, AppConfiguration appConfiguration)
		{
			_locationRepository = locationRepository;
			_userRepository = userRepository;
			_appConfiguration = appConfiguration;
		}


		[Route("")]
		public IActionResult Locations(int page = 1)
		{
			ViewBag.Current = "Locations";

			LocationsViewModel locationsViewModel = new LocationsViewModel
			{
				RollerSkateMapLocations = _locationRepository.GetAllRollerSkateMapLocations().OrderBy(d => d.LocationCreatedDateTime).ToList(),
				RollerSkateMapLocationPerPage = 3,
				CurrentPage = page,
				GoogleApiKey = _appConfiguration.GoogleMapApiKey
			};

			return View(locationsViewModel);
		}

		[Route("{locationId}")]
		public IActionResult Location(int locationId)
		{

			var locationVeiwModel = new LocationViewModel
			{
				RollerSkateMapLocation = _locationRepository.GetRollerSkateMapLocation(locationId),
				GoogleApiKey = _appConfiguration.GoogleMapApiKey
			};

			foreach(var comment in locationVeiwModel.RollerSkateMapLocation.Comments)
            {
				comment.User = _userRepository.GetUser(comment.UserId ?? -1);
            }

			return View(locationVeiwModel);
		}
	}
}