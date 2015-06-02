using Geolocator.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace ForgettingMe
{
    public class MapUtil
    {
        public const int TimeOut = 10000;
        public const int DesiredAccuracy = 50;

        public static async Task<Position> GetPosition()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = DesiredAccuracy;
            var position = await locator.GetPositionAsync(timeout: TimeOut);
            return new Position(position.Latitude, position.Longitude);
        }
    }
}
