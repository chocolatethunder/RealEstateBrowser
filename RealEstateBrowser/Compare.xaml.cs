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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RealEstateBrowser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Compare : Page
    {
        Guid id_1;
        Guid id_2;
        Guid id_3;
        public Compare()
        {
            this.InitializeComponent();

            if(App.user.compare.ElementAt(0).Key != null)
            {
                var cmp1 = App.user.compare.ElementAt(0).Value;
                id_1 = App.user.compare.ElementAt(0).Key;
                c1_baths.Text   = cmp1._bathrooms.ToString();
                c1_beds.Text    = cmp1._bedrooms.ToString();
                c1_price.Text   = "$"+cmp1._price.ToString("#,##0");
                c1_title.Text   = cmp1._title.ToString();
                c1_type.Text    = cmp1._propertyType.ToString();
                c1_img.Source =  new BitmapImage(new Uri(this.BaseUri, "Assets/HousePics/" + cmp1._images[0].ToString()));

                if (cmp1._features["Garage"] == true)
                {
                    c1_Garage.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c1_Garage.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp1._features["Backyard"] == true)
                {
                    c1_Backyard.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c1_Backyard.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp1._features["Furnished"] == true)
                {
                    c1_Furnished.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c1_Furnished.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp1._features["Fireplace"] == true)
                {
                    c1_Fireplace.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c1_Fireplace.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp1._features["Petfriendly"] == true)
                {
                    c1_Petfriendly.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c1_Petfriendly.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

            }

        }

        private void closeCompare_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ClearPage));
        }

        private void remove_c1_Click(object sender, RoutedEventArgs e)
        {
            c1_panel.Visibility = Visibility.Collapsed;
            App.user.compare.Remove(this.id_1);
        }
    }
}
