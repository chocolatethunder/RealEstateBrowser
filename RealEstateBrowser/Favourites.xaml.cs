using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RealEstateBrowser.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RealEstateBrowser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Favourites : Page
    {
        private List<House> houses;

        public Favourites()
        {
            this.InitializeComponent();
            houses = App.user.getFavs();

            if (!houses.Any())
            {
                favsGrid.Visibility = Visibility.Collapsed;
                faveStatus.Visibility = Visibility.Visible;
            }
        }

        private void closeFavourites_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ClearPage));
        }

        private void favsGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            App.currentDetail = (House)e.ClickedItem;
            this.Frame.Navigate(typeof(HouseProperties));
        }
    }
}
