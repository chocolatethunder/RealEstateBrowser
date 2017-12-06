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
    public sealed partial class Question2 : Page
    {
        public Question2()
        {
            this.InitializeComponent();
        }

        private void numBedrooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = numBedrooms.Items[numBedrooms.SelectedIndex] as ComboBoxItem;
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
                App.searchParam.setBedrooms(Int32.Parse(data));
            }
        }

        private void numBathrooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = numBathrooms.Items[numBathrooms.SelectedIndex] as ComboBoxItem;
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
                App.searchParam.setBathrooms(Int32.Parse(data));
            }
        }
    }
}
