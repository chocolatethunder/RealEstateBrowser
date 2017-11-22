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
            /*TransitionCollection collection = new TransitionCollection();
            NavigationThemeTransition theme = new NavigationThemeTransition();

            var info = new ContinuumNavigationTransitionInfo();
            theme.DefaultNavigationTransitionInfo = info;
            collection.Add(theme);
            this.Transitions = collection;*/
        }

        private void searchLocation_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(intro1));
        }
    }
}
