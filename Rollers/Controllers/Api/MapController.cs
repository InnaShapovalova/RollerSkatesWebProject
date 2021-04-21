using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rollers.Utilities.Managers;

namespace Rollers.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : Controller
    {
        private GoogleMapManager _googleMapManager = null;

        public MapController(GoogleMapManager googleMapManager)
        {
            _googleMapManager = googleMapManager;
        }
        [Route("getpositionbyaddress")]
        [HttpPost]
        public async Task<IActionResult> GetPositionByAddress([FromBody] RequestAddress requestAddress)
        {
            return Json(await _googleMapManager.GetLocationByAddress(requestAddress.Address));
        }

        public class RequestAddress
        {
            public string Address { get; set; }
        }


        [Route("getaddressbyposition")]
        [HttpPost]
        public async Task<IActionResult> GetAddressByPosition([FromBody] RequestPosition requestPosition)
        {
            return Json(await _googleMapManager.GetAddressByPosition(requestPosition.Latitude, requestPosition.Longitude));
        }

        public class RequestPosition
        {
            public double Longitude { get; set; }
            public double Latitude { get; set; }
        }
    }
}
