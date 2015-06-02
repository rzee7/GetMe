using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace ForgettingMe
{
    public class MapViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged : Interface Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        private Position _currentPosition = new Position(30.7500, 76.7800); //Temp
        public Position CurrentPosition
        {
            get
            {
                if (_currentPosition.Latitude == 0 && _currentPosition.Longitude == 0)
                    GetCurrentPosition(CityAddress);
                return _currentPosition;
            }
            set { _currentPosition = value; OnPropertyChanged(); }
        }

        private Geocoder _locCoder = new Geocoder();
        public Geocoder LocationCoder
        {
            get { return _locCoder; }
        }

        private string _cityAddress;

        public string CityAddress
        {
            get { return _cityAddress; }
            set { _cityAddress = value; OnPropertyChanged(); IsLocationChanged = true; }
        }

        public bool IsLocationChanged { get; set; }

        #endregion

        #region Quesries

        private async void GetCurrentPosition(string address)
        {
            try
            {
                if (!IsLocationChanged) return;
                var pos = await LocationCoder.GetPositionsForAddressAsync(address);
                if (pos != null)
                    CurrentPosition = pos.ToList().FirstOrDefault();

            }
            catch (Exception ex)
            {
                //TODO: Working for Ex
                Debug.WriteLine("Exception : {0}", ex.Message);
            }
        }

        #endregion
    }
}
