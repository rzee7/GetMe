using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace ForgettingMe
{
    public class Location : BaseModel, ILocation
    {
        private Position _homePosition;
        public Location()
        {
            MapUtil.GetPosition().ContinueWith(t =>
            {
                if (!t.IsFaulted && t.Result != null)
                {
                    _homePosition = t.Result;
                }
            });
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Position HomePosition
        {
            get { return _homePosition; }
            private set { _homePosition = value; OnPropertyChanged("DefaultPosition"); }
        }
    }
}
