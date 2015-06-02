using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgettingMe
{
    /// <summary>
    /// Interface ILocation for latitude & longitude
    /// </summary>
    public interface ILocation
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}
