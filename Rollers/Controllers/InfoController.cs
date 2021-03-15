using Microsoft.AspNetCore.Mvc;

namespace Rollers.Controllers
{
	[Route("[controller]")]
	public class InfoController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Current = "Info";
			return View();
		}
	}
}