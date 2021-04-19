using Microsoft.AspNetCore.Mvc;

namespace Rollers.Controllers
{
	[Route("[controller]")]
	public class InfoController : Controller
	{
		[Route("basics")]
		public IActionResult Basics()
		{
			ViewBag.Current = "Info";
			return View();
		}
		[Route("benefits")]
		public IActionResult Benefits()
		{
			return View();
		}
		[Route("guide")]
		public IActionResult Guide()
		{
			return View();
		}
	}
}