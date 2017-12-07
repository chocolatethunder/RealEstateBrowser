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
            var comboBoxItem = bedMin.Items[bedMin.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                string data = null;
                if (comboBoxItem.Content.ToString().Equals("5+"))
                {
                    data = "5";
                }
                else
                {
                    data = comboBoxItem.Content.ToString();
                }
                App.searchParam.setBedroomMin(Int32.Parse(data));
            }

            comboBoxItem = bedMax.Items[bedMax.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                string data = null;
                if (comboBoxItem.Content.ToString().Equals("5+"))
                {
                    data = "5";
                }
                else
                {
                    data = comboBoxItem.Content.ToString();
                }
                App.searchParam.setBedroomMax(Int32.Parse(data));
            }

            comboBoxItem = bathMin.Items[bathMin.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                string data = null;
                if (comboBoxItem.Content.ToString().Equals("5+"))
                {
                    data = "5";
                }
                else
                {
                    data = comboBoxItem.Content.ToString();
                }
                App.searchParam.setBathroomMin(Int32.Parse(data));
            }

            comboBoxItem = bathMax.Items[bathMax.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                string data = null;
                if (comboBoxItem.Content.ToString().Equals("5+"))
                {
                    data = "5";
                }
                else
                {
                    data = comboBoxItem.Content.ToString();
                }
                App.searchParam.setBathroomMax(Int32.Parse(data));
            }
            
            ComboBoxItem typeItem = (ComboBoxItem)budgetFrom.SelectedItem;
            App.searchParam.setBudgetFrom(Int32.Parse(typeItem.Content.ToString().Replace(",", "").Replace("$", "")));

            typeItem = (ComboBoxItem)budgetTo.SelectedItem;
            App.searchParam.setBudgetTo(Int32.Parse(typeItem.Content.ToString().Replace(",", "").Replace("$", "").Replace("+", "")));

            comboBoxItem = propType.Items[propType.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                App.searchParam.setHouseType(comboBoxItem.Content.ToString());
            }
            
            this.Frame.Navigate(typeof(ClearPage));

            App.mapResultsData.setPushPins(true);

        }        
    }
}
