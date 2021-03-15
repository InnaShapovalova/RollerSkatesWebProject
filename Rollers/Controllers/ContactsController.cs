using Microsoft.AspNetCore.Mvc;

namespace Rollers.Controllers
{
	[Route("[controller]")]
	public class ContactsController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Current = "Contacts";
			return View();
		}
	}
}