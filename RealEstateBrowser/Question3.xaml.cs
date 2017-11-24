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
    public sealed partial class Question3 : Page
    {
        public Question3()
        {
            this.InitializeComponent();
        }

        private void budgetFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)budgetFrom.SelectedItem;
            App.budgetFrom = Int32.Parse(typeItem.Content.ToString().Replace(",","").Replace("$",""));
        }

        private void budgetTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            ComboBoxItem typeItem = (ComboBoxItem)budgetTo.SelectedItem;
            App.budgetTo = Int32.Parse(typeItem.Content.ToString().Replace(",", "").Replace("$", ""));
        }
    }
}
