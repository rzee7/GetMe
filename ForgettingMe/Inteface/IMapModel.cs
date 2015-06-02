using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgettingMe
{
    /// <summary>
    /// Interface IMapModel for details
    /// </summary>
    public interface IMapModel
    {
        string Name { get; set; }
        string Details { get; set; }
        ILocation Location { get; set; }
        string ImageUrl { get; set; }
    }
}
