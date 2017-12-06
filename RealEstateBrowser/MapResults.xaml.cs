using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RealEstateBrowser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapResults : Page
    {
        public MapResults()
        {
            this.InitializeComponent();

            BasicGeoposition location = new BasicGeoposition();
            location.Latitude = App.searchParam.getLat();
            location.Longitude = App.searchParam.getLon();

            MapControl1.Center = new Geopoint(location);
        }

        private void backHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void openFavourites_Click(object sender, RoutedEventArgs e)
        {
            propertyDetails.Navigate(typeof(HouseProperties));
        }

        private void propertyDetails_LostFocus(object sender, RoutedEventArgs e)
        {
            propertyDetails.Navigate(typeof(ClearPage));
        }

        private void advancedOpts_Click(object sender, RoutedEventArgs e)
        {
            optionsModal.Navigate(typeof(AdvancedOptions));
        }

        /*
        private async void Test_Me(object sender, RoutedEventArgs e)
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(HouseProperties), null);
                Window.Current.Content = frame;
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }
        */
    }
}
