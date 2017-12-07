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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RealEstateBrowser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdvancedOptions : Page
    {
        
        public AdvancedOptions()
        {
            this.InitializeComponent();
        }

        private void closeProperty_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ClearPage));
        }

        private void refineSearch_Click(object sender, RoutedEventArgs e)
        {
            Boolean error = false;

            // **************************************** //

            string BedMin = null;
            string BedMax = null;

            var comboBoxItem = bedMin.Items[bedMin.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                
                if (comboBoxItem.Content.ToString().Equals("5+"))
                {
                    BedMin = "5";
                }
                else
                {
                    BedMin = comboBoxItem.Content.ToString();
                }
                
            }

            comboBoxItem = bedMax.Items[bedMax.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                
                if (comboBoxItem.Content.ToString().Equals("5+"))
                {
                    BedMax = "5";
                }
                else
                {
                    BedMax = comboBoxItem.Content.ToString();
                }
                
            }

            if (Int32.Parse(BedMax) < Int32.Parse(BedMin))
            {
                errorSymbol.Text = "\xE783";
                errorMsg.Text = "Incorrect range for Bedrooms";
                error = true;
                return;
            }
            else
            {               
                App.searchParam.setBedroomMin(Int32.Parse(BedMin));
                App.searchParam.setBedroomMax(Int32.Parse(BedMax));
            }

            // **************************************** //

            string BathMin = null;
            string BathMax = null;

            comboBoxItem = bathMin.Items[bathMin.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                if (comboBoxItem.Content.ToString().Equals("5+"))
                {
                    BathMin = "5";
                }
                else
                {
                    BathMin = comboBoxItem.Content.ToString();
                }
                App.searchParam.setBathroomMin(Int32.Parse(BathMin));
            }

            comboBoxItem = bathMax.Items[bathMax.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                if (comboBoxItem.Content.ToString().Equals("5+"))
                {
                    BathMax = "5";
                }
                else
                {
                    BathMax = comboBoxItem.Content.ToString();
                }
                App.searchParam.setBathroomMax(Int32.Parse(BathMax));
            }

            if (Int32.Parse(BathMax) < Int32.Parse(BathMin))
            {
                errorSymbol.Text = "\xE783";
                errorMsg.Text = "Incorrect range for Bathrooms";
                error = true;
                return;
            }
            else
            {
                App.searchParam.setBedroomMin(Int32.Parse(BathMin));
                App.searchParam.setBedroomMax(Int32.Parse(BathMax));
            }

            // **************************************** //

            ComboBoxItem typeItem = (ComboBoxItem)budgetFrom.SelectedItem;
            App.searchParam.setBudgetFrom(Int32.Parse(typeItem.Content.ToString().Replace(",", "").Replace("$", "")));

            // **************************************** //

            typeItem = (ComboBoxItem)budgetTo.SelectedItem;
            App.searchParam.setBudgetTo(Int32.Parse(typeItem.Content.ToString().Replace(",", "").Replace("$", "").Replace("+", "")));

            // **************************************** //

            comboBoxItem = propType.Items[propType.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                App.searchParam.setHouseType(comboBoxItem.Content.ToString());
            }

            // **************************************** //

            if (!string.IsNullOrWhiteSpace(sqftFrom.Text) && !string.IsNullOrWhiteSpace(sqftTo.Text)) 
            {
                try
                {
                    int sqFrom = Int32.Parse(sqftFrom.Text);
                    int sqTo = Int32.Parse(sqftTo.Text);

                    if (sqTo < sqFrom)
                    {
                        errorSymbol.Text = "\xE783";
                        errorMsg.Text = "Incorrect range for square footage";
                        error = true;
                        return;
                    }
                    else
                    {
                        App.searchParam.setSquareFtLow(sqFrom);
                        App.searchParam.setSquareFtHigh(sqTo);
                    }

                }
                catch (Exception err)
                {
                    errorSymbol.Text = "\xE783";
                    errorMsg.Text = "Please check your square footage values";
                    error = true;
                    return;
                }
            }
            

            // **************************************** //
            
            if (Garage.IsChecked == true)
            {
                App.searchParam.feature("Garage", true);
            }
            else
            {
                App.searchParam.feature("Garage", false);
            }

            if (Backyard.IsChecked == true)
            {
                App.searchParam.feature("Backyard", true);
            }
            else
            {
                App.searchParam.feature("Backyard", false);
            }

            if (Furnished.IsChecked == true)
            {
                App.searchParam.feature("Furnished", true);
            }
            else
            {
                App.searchParam.feature("Furnished", false);
            }

            if (Fireplace.IsChecked == true)
            {
                App.searchParam.feature("Fireplace", true);
            }
            else
            {
                App.searchParam.feature("Fireplace", false);
            }

            if (Petfriendly.IsChecked == true)
            {
                App.searchParam.feature("Petfriendly", true);
            }
            else
            {
                App.searchParam.feature("Petfriendly", false);
            }

            /***********************************************/

            if (!string.IsNullOrWhiteSpace(searchTags.Text))
            {
                var text = searchTags.Text;
                List<String> tokens = text.Replace("#", " ").Replace(",", " ").Split(' ').ToList();
                App.searchParam.setSearchTags(tokens);
            }
            else
            {
                App.searchParam.setSearchTags(null);
            }

            // Only process if no errors
            if (!error)
            {
                this.Frame.Navigate(typeof(ClearPage));
                App.mapResultsData.setPushPins(true);
            }
            

        }

    }
}
