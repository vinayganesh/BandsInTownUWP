using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace BandsInTownUWP.IServices
{
    public interface IGeoCoderService
    {
        Task<Geoposition> GetCurrentGeoPosition();

        Tuple<double, double> GetLatLongFromLocation(Geoposition position);

        Task<string> GetLocationFromLatLong();

        string TimeZoneConverter(string time);
    }
}
