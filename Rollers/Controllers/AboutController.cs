using Microsoft.AspNetCore.Mvc;

namespace Rollers.Controllers
{
	[Route("[controller]")]
	public class AboutController : Controller
	{ 
		public IActionResult Index()
		{
			ViewBag.Current = "About";
			return View();
		}
	}
}