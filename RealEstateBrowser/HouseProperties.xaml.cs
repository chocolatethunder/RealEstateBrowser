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

        }

        private void closeProperty_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ClearPage));
        }

    }
}
