using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetBooks()
        {
            return Ok(new
            {
                Book1 = "str",
                Book2 = "str",
                Book3 = "str",
                Book4 = "str",
                Book5 = "str"
            }) ;
        }
    }
}
