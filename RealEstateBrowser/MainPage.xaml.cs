using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
                errorMsg.Text = "Please enter a location";
                errorSymbol.Text = "\xE783";
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
        }

        private async void autoLocate_Click(object sender, RoutedEventArgs e)
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            searchingWait.IsActive = true;
            autoLocate.Background = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
            autoLocate.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            location.IsEnabled = false;
            searchLocation.IsEnabled = false;

            /*
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    _rootPage.NotifyUser("Waiting for update...", NotifyType.StatusMessage);

                    // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };


                    // Carry out the operation.
                    Geoposition pos = await geolocator.GetGeopositionAsync();

                    _rootPage.NotifyUser("Location updated.", NotifyType.StatusMessage);
                    break;

                case GeolocationAccessStatus.Denied:
                    _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);
                    LocationDisabledMessage.Visibility = Visibility.Visible;
                    UpdateLocationData(null);
                    break;

                case GeolocationAccessStatus.Unspecified:
                    _rootPage.NotifyUser("Unspecified error.", NotifyType.ErrorMessage);
                    UpdateLocationData(null);
                    break;
            }*/

        }
    }
}
