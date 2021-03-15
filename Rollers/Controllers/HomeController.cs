using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rollers.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Current = "Home";
            return View();
        }
    }
}
