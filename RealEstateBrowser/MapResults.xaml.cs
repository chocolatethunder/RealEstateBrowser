using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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

            int budgetRange = App.searchParam.getBudgetTo() - App.searchParam.getBudgetFrom();
            int budgetDivide = budgetRange / 3;
            int startBudget = App.searchParam.getBudgetFrom();
            int tier1 = startBudget + budgetDivide;
            int tier2 = startBudget + budgetDivide * 2;
            int tier3 = startBudget + budgetDivide * 3;

            // Setup all the push pins

            foreach (House listing in App.searchParam.getSearchResults())
            {
                var pushPin = new MapIcon();
                pushPin.Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = listing._latitude,
                    Longitude = listing._longitude
                });
                pushPin.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;
                pushPin.NormalizedAnchorPoint = new Point(0.5, 0.80);

                if (listing._price > startBudget && listing._price < tier1)
                {
                    var myImageUri = new Uri("ms-appx:///Assets/icon-low.png");
                    pushPin.Image = RandomAccessStreamReference.CreateFromUri(myImageUri);
                }
                else if (listing._price >= tier1 && listing._price < tier2)
                {
                    var myImageUri = new Uri("ms-appx:///Assets/icon-mid.png");
                    pushPin.Image = RandomAccessStreamReference.CreateFromUri(myImageUri);
                }
                else if (listing._price >= tier2)
                {
                    var myImageUri = new Uri("ms-appx:///Assets/icon-high.png");
                    pushPin.Image = RandomAccessStreamReference.CreateFromUri(myImageUri);
                }

                MapControl1.MapElements.Add(pushPin);
            }

        }

        private void backHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void openFavourites_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void propertyDetails_LostFocus(object sender, RoutedEventArgs e)
        {
            propertyDetails.Navigate(typeof(ClearPage));
        }

        private void advancedOpts_Click(object sender, RoutedEventArgs e)
        {
            optionsModal.Navigate(typeof(AdvancedOptions));
        }

        private void MapControl1_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            MapIcon myClickedIcon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;

            foreach (House listing in App.searchParam.getSearchResults())
            {
                if (myClickedIcon.Location.Position.Latitude == listing._latitude && myClickedIcon.Location.Position.Longitude == listing._longitude)
                {
                    App.currentDetail = listing;
                    propertyDetails.Navigate(typeof(HouseProperties));
                }
            }
        }

    }
}
