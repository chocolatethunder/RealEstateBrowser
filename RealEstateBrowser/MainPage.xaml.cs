using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RealEstateBrowser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            location.AddHandler(AutoSuggestBox.KeyDownEvent, new KeyEventHandler(location_KeyDown), true);
        }

        private void searchLocation_Click(object sender, RoutedEventArgs e)
        {
            if (!location.Text.Equals(null) && !location.Text.Equals(""))
            {
                this.storeSearch();
                this.Frame.Navigate(typeof(intro));
            }
            else
            {
                errorSymbol.Text = "\xE783";
                errorMsg.Text = "Please enter a location";
            }
        }

        private void storeSearch()
        {
            App.previousSearches.Add(location.Text);
        }

        private void location_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var autosuggest = (AutoSuggestBox)sender;
            var filtered = App.previousSearches.Where(p => p.StartsWith(autosuggest.Text)).ToArray();
            autosuggest.ItemsSource = filtered;
        }

        private void location_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                searchLocation_Click(sender, e);
            }
        }

        private void reset()
        {
            location.IsEnabled = true;
            searchLocation.IsEnabled = true;
            searchingWait.IsActive = false;
            autoLocate.Background = new SolidColorBrush(Color.FromArgb(51, 0, 0, 0));
        }

        private async void autoLocate_Click(object sender, RoutedEventArgs e)
        {

            searchingWait.IsActive = true;
            autoLocate.Background = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
            location.IsEnabled = false;
            searchLocation.IsEnabled = false;

            var gpsAccess = await Geolocator.RequestAccessAsync();

            switch (gpsAccess)
            {
                case GeolocationAccessStatus.Allowed:
                    Geolocator geoLocator = new Geolocator { DesiredAccuracy = PositionAccuracy.Default };
                    Geoposition pos = await geoLocator.GetGeopositionAsync();
                    BasicGeoposition coords = new BasicGeoposition();
                    coords.Latitude = pos.Coordinate.Point.Position.Latitude;
                    coords.Longitude = pos.Coordinate.Point.Position.Longitude;
                    Geopoint coordsToReverse = new Geopoint(coords);
                    MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(coordsToReverse);

                    if(result.Status == MapLocationFinderStatus.Success)
                    {
                        location.Text = result.Locations[0].Address.Town;
                        errorSymbol.Text = "";
                        errorMsg.Text = "";
                    }
                    else
                    {
                        errorSymbol.Text = "\xE783";
                        errorMsg.Text = "We couldn't find your location.";
                    }
                    break;

                case GeolocationAccessStatus.Denied:
                    errorSymbol.Text = "\xE783";
                    errorMsg.Text = "Please enable location access";
                    await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
                    break;

                case GeolocationAccessStatus.Unspecified:
                    errorSymbol.Text = "\xE783";
                    errorMsg.Text = "An unknown error occured";
                    break;
            }

            this.reset();
        }
    }
}
