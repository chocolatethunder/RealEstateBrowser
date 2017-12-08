using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RealEstateBrowser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HouseProperties : Page
    {
        public HouseProperties()
        {
            this.InitializeComponent();
            sellerAvatar.Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/Sellers/"+App.currentDetail._seller.ToString())) };
            propTitle.Text = App.currentDetail._title;
            propDescription.Text = App.currentDetail._description;
            propPrice.Text = "$"+App.currentDetail._price.ToString("#,##0");
            bedrooms.Text = App.currentDetail._bedrooms.ToString();
            bathrooms.Text = App.currentDetail._bathrooms.ToString();
            proptype.Text = App.currentDetail._propertyType;
            squareFt.Text = App.currentDetail._area.ToString("#,##0") + " sqft";

            foreach (KeyValuePair<String,Boolean> feature in App.currentDetail._features)
            {
                if (feature.Key.Equals("Garage") && feature.Value == true)
                {
                    Garage.Fill = new SolidColorBrush(Color.FromArgb(255,17,191,219));
                    Garage.Stroke = new SolidColorBrush(Color.FromArgb(255,0,0,0));
                }

                if (feature.Key.Equals("Backyard") && feature.Value == true)
                {
                    Backyard.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    Backyard.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (feature.Key.Equals("Furnished") && feature.Value == true)
                {
                    Furnished.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    Furnished.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (feature.Key.Equals("Fireplace") && feature.Value == true)
                {
                    Fireplace.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    Fireplace.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (feature.Key.Equals("Petfriendly") && feature.Value == true)
                {
                    Petfriendly.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    Petfriendly.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }
            }

            if (App.user.compare.ContainsKey(App.currentDetail._id))
            {
                compareButt.Background = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219)); 
                compareButtTxt.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }

            if (App.user.favs.ContainsKey(App.currentDetail._id))
            {
                heart.Text = "\xEB52";
            }

        }

        private void closeProperty_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
            else
            {
                this.Frame.Navigate(typeof(ClearPage));
            }            
        }

        private void addToFavs_Click(object sender, RoutedEventArgs e)
        {
            if (App.user.favs.ContainsKey(App.currentDetail._id))
            {
                heart.Text = "\xEB51";
                App.user.favs.Remove(App.currentDetail._id);
            }
            else
            {
                if (App.user.addToFavs(App.currentDetail))
                {
                    heart.Text = "\xEB52";
                }                
            }
        }

        private void addToCompare_Click(object sender, RoutedEventArgs e)
        {
            if (App.user.compare.Count() >= 3)
            {
                showError("You cannot add more than 3 item to compare list");
            }
            else if (App.user.compare.ContainsKey(App.currentDetail._id))
            {
                compareButt.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                compareButtTxt.Foreground = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                App.user.compare.Remove(App.currentDetail._id);
            }
            else
            {
                if (App.user.addToCompare(App.currentDetail))
                {
                    compareButt.Background = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    compareButtTxt.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                }                
            }
        }

        private async void showError(String msg)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Error",
                MaxWidth = this.ActualWidth,
                PrimaryButtonText = "OK",
                Content = new TextBlock
                {
                    Text = msg,
                    FontSize = 18
                }
            };
            await dialog.ShowAsync();

        }

        private void propInterested_Click(object sender, RoutedEventArgs e)
        {
            // Height is only important if we want the Popup sized to the screen 
            //ppup.Height = Window.Current.Bounds.Height;
            ppup.IsOpen = true;
        }

        private void sendButt_Click(object sender, RoutedEventArgs e)
        {
            ppup.IsOpen = false;
        }
    }
}
