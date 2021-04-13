using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Utilities.Managers
{
    public class GoogleMapManager
    {
        private AppConfiguration _appConfiguration = null;
        public GoogleMapManager(AppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task<Location> GetLocationByAddress(string address)
        {
            IGeocoder geocoder = new GoogleGeocoder()
            {
                ApiKey = _appConfiguration.GoogleMapApiKey
            };
        IEnumerable<Address> addresses = await geocoder.GeocodeAsync(address);
            
            return addresses.First()?.Coordinates ?? new Location(0, 0);
        }

        public async Task<string> GetAddressByPosition(double latitude, double longitude)
        {
            IGeocoder geocoder = new GoogleGeocoder()
            {
                ApiKey = _appConfiguration.GoogleMapApiKey
            };

            IEnumerable<Address> addresses = await geocoder.ReverseGeocodeAsync(new Location(latitude, longitude));

            return addresses.First()?.FormattedAddress ?? "";
        }
    }
}
