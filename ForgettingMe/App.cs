using System;
using Xamarin.Forms;

/*
Glyphish icons from
	http://www.glyphish.com/
under 
	http://creativecommons.org/licenses/by/3.0/us/
support them by buying the full set / Retina versions
*/

namespace ForgettingMe
{
	public class App : Application // superclass new in 1.3
	{
		public App ()
		{

            //var tabs = new TabbedPage ();

            MainPage = new NavigationPage(new MapPage { Title = "Forgetting? ", Icon = "glyphish_location.png" });
		}
	}
}

