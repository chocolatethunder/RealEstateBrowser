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
        List<Guid> id = new List<Guid>();

        public Compare()
        {
            this.InitializeComponent();

            c1_panel.Visibility = Visibility.Collapsed;
            c2_panel.Visibility = Visibility.Collapsed;
            c3_panel.Visibility = Visibility.Collapsed;

            int i = 0;
            while (i < App.user.compare.Count())
            {
                if(App.user.compare.ElementAt(i).Key != null)
                {
                    this.id.Add(App.user.compare.ElementAt(i).Key);
                }
                i++;
            }

            if(this.id.Count() >= 1 && this.id.ElementAt(0) != null)
            {
                var cmp1 = App.user.compare[this.id.ElementAt(0)];
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

                c1_panel.Visibility = Visibility.Visible;

            }

            if (this.id.Count() >= 2 && this.id.ElementAt(1) != null)
            {
                var cmp2 = App.user.compare[this.id.ElementAt(1)];
                c2_baths.Text = cmp2._bathrooms.ToString();
                c2_beds.Text = cmp2._bedrooms.ToString();
                c2_price.Text = "$" + cmp2._price.ToString("#,##0");
                c2_title.Text = cmp2._title.ToString();
                c2_type.Text = cmp2._propertyType.ToString();
                c2_img.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/HousePics/" + cmp2._images[0].ToString()));

                if (cmp2._features["Garage"] == true)
                {
                    c2_Garage.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c2_Garage.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp2._features["Backyard"] == true)
                {
                    c2_Backyard.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c2_Backyard.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp2._features["Furnished"] == true)
                {
                    c2_Furnished.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c2_Furnished.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp2._features["Fireplace"] == true)
                {
                    c2_Fireplace.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c2_Fireplace.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp2._features["Petfriendly"] == true)
                {
                    c2_Petfriendly.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c2_Petfriendly.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                c2_panel.Visibility = Visibility.Visible;

            }

            if (this.id.Count() >= 3 && this.id.ElementAt(2) != null)
            {
                var cmp3 = App.user.compare[this.id.ElementAt(2)];
                c3_baths.Text = cmp3._bathrooms.ToString();
                c3_beds.Text = cmp3._bedrooms.ToString();
                c3_price.Text = "$" + cmp3._price.ToString("#,##0");
                c3_title.Text = cmp3._title.ToString();
                c3_type.Text = cmp3._propertyType.ToString();
                c3_img.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/HousePics/" + cmp3._images[0].ToString()));

                if (cmp3._features["Garage"] == true)
                {
                    c3_Garage.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c3_Garage.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp3._features["Backyard"] == true)
                {
                    c3_Backyard.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c3_Backyard.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp3._features["Furnished"] == true)
                {
                    c3_Furnished.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c3_Furnished.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp3._features["Fireplace"] == true)
                {
                    c3_Fireplace.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c3_Fireplace.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                if (cmp3._features["Petfriendly"] == true)
                {
                    c3_Petfriendly.Fill = new SolidColorBrush(Color.FromArgb(255, 17, 191, 219));
                    c3_Petfriendly.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                }

                c3_panel.Visibility = Visibility.Visible;

            }

        }

        private void closeCompare_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ClearPage));
        }

        private void remove_c1_Click(object sender, RoutedEventArgs e)
        {
            c1_panel.Visibility = Visibility.Collapsed;
            App.user.compare.Remove(this.id.ElementAt(0));
            this.id.RemoveAt(0);
            if (!this.id.Any())
            {
                compareStatus.Visibility = Visibility.Collapsed;
                compareStatus.Visibility = Visibility.Visible;
            }
        }

        private void remove_c2_Click(object sender, RoutedEventArgs e)
        {
            c2_panel.Visibility = Visibility.Collapsed;
            App.user.compare.Remove(this.id.ElementAt(1));
            this.id.RemoveAt(1);
            if (!this.id.Any())
            {
                compareStatus.Visibility = Visibility.Collapsed;
                compareStatus.Visibility = Visibility.Visible;
            }
        }

        private void remove_c3_Click(object sender, RoutedEventArgs e)
        {
            c3_panel.Visibility = Visibility.Collapsed;
            App.user.compare.Remove(this.id.ElementAt(2));
            this.id.RemoveAt(2);
            if (!this.id.Any())
            {
                compareStatus.Visibility = Visibility.Collapsed;
                compareStatus.Visibility = Visibility.Visible;
            }
        }

    }
}
