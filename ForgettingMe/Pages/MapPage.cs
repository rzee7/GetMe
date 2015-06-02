using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace ForgettingMe
{
    public class MapPage : BasePage
    {

        public MapViewModel ViewModel { get { return BindingContext as MapViewModel; } }

        Map MapView;
        public MapPage()
        {

            BindingContext = new MapViewModel();
            ViewModel.CityAddress = "Chandigarh India";
            MapView = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            
           //  You can use MapSpan.FromCenterAndRadius 
            MapView.MoveToRegion(MapSpan.FromCenterAndRadius(ViewModel.CurrentPosition, Distance.FromMiles(5)));
            // or create a new MapSpan object directly

            var zoomLevel = 18; // between 1 and 18
            var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
           // MapView.MoveToRegion(new MapSpan(ViewModel.CurrentPosition, 360, 360));

            //MapView.MoveToRegion(new MapSpan(MapView.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            
            // put the page together
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(MapView);
            Content = stack;

            // for debugging output only
            MapView.PropertyChanged += (sender, e) =>
            {
                Debug.WriteLine(e.PropertyName + " just changed!");
                if (e.PropertyName == "VisibleRegion" && MapView.VisibleRegion != null)
                    CalculateBoundingCoordinates(MapView.VisibleRegion);
            };
        }

        void HandleClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Street":
                    MapView.MapType = MapType.Street;
                    break;
                case "Hybrid":
                    MapView.MapType = MapType.Hybrid;
                    break;
                case "Satellite":
                    MapView.MapType = MapType.Satellite;
                    break;
            }
        }



        /// <summary>
        /// In response to this forum question http://forums.xamarin.com/discussion/22493/maps-visibleregion-bounds
        /// Useful if you need to send the bounds to a web service or otherwise calculate what
        /// pins might need to be drawn inside the currently visible viewport.
        /// </summary>
        static void CalculateBoundingCoordinates(MapSpan region)
        {
            // WARNING: I haven't tested the correctness of this exhaustively!
            var center = region.Center;
            var halfheightDegrees = region.LatitudeDegrees / 2;
            var halfwidthDegrees = region.LongitudeDegrees / 2;

            var left = center.Longitude - halfwidthDegrees;
            var right = center.Longitude + halfwidthDegrees;
            var top = center.Latitude + halfheightDegrees;
            var bottom = center.Latitude - halfheightDegrees;

            // Adjust for Internation Date Line (+/- 180 degrees longitude)
            if (left < -180) left = 180 + (180 + left);
            if (right > 180) right = (right - 180) - 180;
            // I don't wrap around north or south; I don't think the map control allows this anyway

            Debug.WriteLine("Bounding box:");
            Debug.WriteLine("                    " + top);
            Debug.WriteLine("  " + left + "                " + right);
            Debug.WriteLine("                    " + bottom);
        }
    }
}
