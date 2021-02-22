using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BunkerGearController: Controller
    {
        public IActionResult Index()
        {
            return View("BunkerGear");  
        }
    }
}
