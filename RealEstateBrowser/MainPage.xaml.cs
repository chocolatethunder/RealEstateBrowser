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

    }
}
