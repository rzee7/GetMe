﻿using System;
using Xamarin.Forms;

namespace ForgettingMe
{
	public class MapAppPage : ContentPage
	{
		// WARNING: when adding latitude/longitude values be careful of localization.
		// European (and other countries) use a comma as the separator, which will break the request

		public MapAppPage ()
		{
			var l = new Label {
				Text = "These buttons leave the current app and open the built-in Maps app for the platform"
			};

			var openLocation = new Button {
				Text = "Open location using built-in Maps app"
			};
			openLocation.Clicked += (sender, e) => {

				if (Device.OS == TargetPlatform.iOS) {
					//https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
					Device.OpenUri(new Uri("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA"));
				} else if (Device.OS == TargetPlatform.Android) {
					// opens the Maps app directly
					Device.OpenUri(new Uri("geo:0,0?q=394+Pacific+Ave+San+Francisco+CA"));

				} else if (Device.OS == TargetPlatform.WinPhone) {
					DisplayAlert("To Do", "Not yet implemented", "OK");
				}
			};

			var openDirections = new Button {
				Text = "Get directions using built-in Maps app"
			};
			openDirections.Clicked += (sender, e) => {

				if (Device.OS == TargetPlatform.iOS) {
					//https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
					Device.OpenUri(new Uri("http://maps.apple.com/?daddr=San+Francisco,+CA&saddr=cupertino"));

				} else if (Device.OS == TargetPlatform.Android) {
					// opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
					Device.OpenUri(new Uri("http://maps.google.com/?daddr=San+Francisco,+CA&saddr=Mountain+View"));

				} else if (Device.OS == TargetPlatform.WinPhone) {
					DisplayAlert("To Do", "Not yet implemented", "OK");
				}
			};

			Content = new StackLayout{
				Padding = new Thickness (5, 20, 5, 0),
				HorizontalOptions = LayoutOptions.Fill,
				Children = {
					l,
					openLocation,
					openDirections
				}
			};
		}
	}
}

