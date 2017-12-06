using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RealEstateBrowser
{

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {

        internal static Search searchParam = new Search();
        internal static List<House> listings = new List<House>();
        internal static House currentDetail;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            MapService.ServiceToken = "yfqhsxtMlfp8jyAdLVBi~9GDeJrGkXBNGOmqnMBv_Bg~AqJfnPmjTda3MTiQXJvoskz5DrGMRyEv5d6NEqNQLC9MSJQxZjPtWb0_ZfSIXHCK";

            // Fake Real Estate Data
            
            App.listings.Add(new House(
                51.0098224, 
                -114.1044374, 
                2, 
                2, 
                1360, 
                500000, 
                new List<String>() { "Assets/HousePics/house-1-1.jpeg", "Assets/HousePics/house-1-2.jpeg" }, 
                "House", 
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Driveway", true }, { "Frontyard", true }, { "Fireplace", true } },
                "A beautiful home",
                "You will love this place. Been built in 2015."
                )
            );

            App.listings.Add(new House(
                51.1317108,
                -114.1478676,
                2,
                2,
                1360,
                800000,
                new List<String>() { "Assets/HousePics/house-1-1.jpeg", "Assets/HousePics/house-1-2.jpeg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Driveway", true }, { "Frontyard", true }, { "Fireplace", true } },
                "A cosy home",
                "You will love this place. Been built in 1998."
                )
            );

            App.listings.Add(new House(
                51.0699442,
                -113.9276259,
                2,
                2,
                1360,
                250000,
                new List<String>() { "Assets/HousePics/house-1-1.jpeg", "Assets/HousePics/house-1-2.jpeg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Driveway", true }, { "Frontyard", true }, { "Fireplace", true } },
                "Very unique home",
                "Try not to get shot. It is in a sketchy area."
                )
            );

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
