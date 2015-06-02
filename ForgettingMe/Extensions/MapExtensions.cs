using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace ForgettingMe
{
    public static class MapExtensions
    {
        public static IList<Pin> ToPins<T>(this IEnumerable<T> items) where T : IMapModel
        {
            return items.Select(i => i.AsPin()).ToList();
        }
        public static Pin AsPin(this IMapModel item)
        {
            var location = item.Location;
            var position = location != null ? new Position(location.Latitude, location.Longitude) : new Location().HomePosition;
            return new Pin { Label = item.Name, Address = item.Details, Position = position };
        }
    }
}
