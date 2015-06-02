using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ForgettingMe
{
    public class LocationMapView : Map
    {
        #region Private fields

        private readonly ObservableCollection<IMapModel> _items = new ObservableCollection<IMapModel>();
        private MapSpan _visibleRegion;

        #endregion

        #region Constructor

        public LocationMapView(MapSpan region)
            : base(region)
        {

        }

        #endregion

        #region Public Properties

        public static readonly BindableProperty SelectedPinProperty = BindableProperty.Create<LocationMapView, LocationPin>(x => x.SelectedPin, null);

        public LocationPin SelectedPin
        {
            get { return base.GetValue(SelectedPinProperty) as LocationPin; }
            set { base.SetValue(SelectedPinProperty, value); }
        }

        public MapSpan LastMoveToRegion { get; private set; }

        public new MapSpan VisibleRegion
        {
            get { return _visibleRegion; }
            set
            {
                if (_visibleRegion == value)
                {
                    return;
                }
                if (value == null)
                {
                    throw new ArgumentNullException("VisibleRegion: value");
                }

                OnPropertyChanging("VisibleRegion");
                _visibleRegion = value;
                OnPropertyChanged("VisibleRegion");
            }
        }

        public ObservableCollection<IMapModel> Items
        {
            get { return _items; }
        }

       

        #endregion

        #region Method : Update Pin

        public void UpdatePins(IEnumerable<IMapModel> items)
        {
            Pins.Clear();
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
                Pins.Add(item.AsPin());
            }
        }

        #endregion

        #region Commands

        public ICommand ShowDetailCommand { get; set; }

        #endregion
    }
}
