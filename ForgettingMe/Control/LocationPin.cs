using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgettingMe
{
    public class LocationPin : IMapModel
    {
        public LocationPin(string name, string details, double latitude, double longitude)
        {
            Name = name;
            Details = details;
            Location = new Location { Latitude = latitude, Longitude = longitude };
        }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public ILocation Location { get; set; }
    }
}
