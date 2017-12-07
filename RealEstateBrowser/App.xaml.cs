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
        internal static User user = new User();
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
                new List<String>() { "house-1-1.jpeg", "house-1-2.jpeg" }, 
                "House", 
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "A beautiful home",
                "You will love this place. Been built in 2015. Looking for that perfect house? Well you've come to the right place. This is a one of a kind an amazing home where you and your dog can live in peace. You can also shoot the neighbours if they come across your lawn.",
                "dude-1.png",
                new String[] { "cosy", "homely", "pets"}
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
                "Townhouse",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", false } },
                "A cosy home",
                "You will love this place. Been built in 1998.",
                "girl-1.png",
                new String[] { "lovely", "furnished", "closttotransit" }
                )
            );

            App.listings.Add(new House(
                51.0699442,
                -113.9276259,
                2,
                2,
                1360,
                2500000,
                new List<String>() { "Assets/HousePics/house-1-1.jpeg", "Assets/HousePics/house-1-2.jpeg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", true }, { "Fireplace", true }, { "Petfriendly", false } },
                "Very unique home",
                "Try not to get shot. It is in a sketchy area.",
                "dude-3.png",
                new String[] { "deadly", "scared", "murder" }
                )
            );

            App.listings.Add(new House(
                51.1782883,
                -114.1121236,
                1,
                1,
                751,
                124100,
                new List<String>() { "house1.jpg"},
                "Condo",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", false }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "Well maintain 1 Bedroom Condo",
                "This unit features bright and large Living area with cozy wood burning fireplace, 4 piece bathroom, spacious master bedroom and a kitchen.",
                "dude-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.1000571,
                -114.0874426,
                3,
                2,
                910,
                339900,
                new List<String>() { "house2.jpg" },
                "Townhouse",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", false }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "Great location in North Haven",
                "Main level has hardwood floors in living room and vaulted ceilings. Refinished kitchen and newer lighting. Great for investment or to live in and rent down.",
                "girl-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.0806767,
                -114.1075097,
                2,
                1,
                896,
                249000,
                new List<String>() { "house3.jpg" },
                "Condo",
                new Dictionary<String, Boolean>() { { "Garage", false }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", false }, { "Petfriendly", false } },
                "This home has everything",
                "Inside find laminate flooring, cute galley kitchen, 2 bedrooms & one full bath. Lots of closets for storage & a living room measuring over 250 sq ft.",
                "dude-3.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.1412157,
                -114.1547247,
                4,
                4,
                1711,
                535000,
                new List<String>() { "house4.jpg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "4 bedroom house in a fantastic location",
                "Clay tile roof and new paint throughout. Windows replaced in 2015. All appliances replaced in past three years.",
                "dude-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.1450651,
                -114.2111747,
                5,
                4,
                1926,
                509900,
                new List<String>() { "house5.jpg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "Stunning family home located on quiet cul-de-sac",
                "Dramatic vaulted ceilings, beautiful hardwood floors in living room, dining room, family room and den.",
                "girl-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.1455944,
                -114.0604588,
                5,
                4,
                1492,
                454000,
                new List<String>() { "house6.jpg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", true }, { "Fireplace", true }, { "Petfriendly", true } },
                "Beautifully landscaped. Boasts a total of 5 Bedrooms",
                "Ensuit with his and hers closets. Mainfloor features large kitchen with oak cabinets, nook area with patio doors.",
                "girl-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.0454261,
                -114.1944835,
                5,
                6,
                3549,
                1998000,
                new List<String>() { "house7.jpg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "This exquisite Aspen Woods home is going to impress you in so many ways!",
                "Stepping inside, you'll begin to admire the impeccable craftsmanship and upscale design. The large foyer introduces the main floor with beautiful cabinetry for storage, and a lovely sitting bench.",
                "dude-3.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.0565263,
                -114.0461862,
                4,
                4,
                3700,
                1995000,
                new List<String>() { "house8.jpg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "Executive 2 storey family home in Bridgeland with downtown views",
                " Large foyer leads you into a bright open floor plan featuring a large gourmet kitchen with walkin pantry, stainless steel appliances, spacious dining room with barn board feature wall, great room with gorgeous fireplace wall.",
                "dude-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.0644932,
                -114.1127164,
                5,
                5,
                3547,
                1995000,
                new List<String>() { "house9.jpg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "European inspired residence",
                "An impressive foyer with formal dining room to one side and private office on the other leads to the great room with expansive built ins surrounding the fireplace and floor to ceiling windows.",
                "girl-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.0818943,
                -114.1726827,
                5,
                5,
                4481,
                1385000,
                new List<String>() { "house10.jpg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "Located in the historic community of Bowness",
                "This exceptional custom built home has over 4481 ft² of developed living space highlighted by extraordinary finishes, triple pane windows, 10' ceilings, underground sprinkler system & an oversized double car garage.",
                "dude-3.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                50.9445121,
                -113.9928244,
                2,
                3,
                2020,
                849000,
                new List<String>() { "house11.jpg" },
                "House",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", true }, { "Furnished", true }, { "Fireplace", true }, { "Petfriendly", false } },
                "Beautifully renovated home",
                "Just off the entry is a lovely den that can be converted to a bedroom. The dining room beyond draws you in to the rear where the beautiful family room is located.",
                "dude-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                50.9456594,
                -114.1385007,
                3,
                2,
                912,
                274900,
                new List<String>() { "house12.jpg" },
                "Condo",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", false }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", false } },
                " Move in ready condo.",
                "The newly upgraded flooring greets you as you enter the home as the large windows flood the rooms with natural light.",
                "girl-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                49.2275828,
                -123.1199402,
                3,
                4,
                1582,
                1650000,
                new List<String>() { "house13.jpg" },
                "Townhouse",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", false }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "Large townhouse",
                "Easy access to Downtown, Richmond & UBC. The townhouse features approximate 470 square ft rooftop deck & double side by side private 2 car garage attached to the unit.",
                "girl-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                49.2866273,
                -123.1386911,
                3,
                2,
                1088,
                1098000,
                new List<String>() { "house14.jpg" },
                "Townhouse",
                new Dictionary<String, Boolean>() { { "Garage", false }, { "Backyard", true }, { "Furnished", false }, { "Fireplace", false }, { "Petfriendly", true } },
                "Modern home on a quiet car free road",
                "This garden level suite with sunny west facing outdoor space is part of two classic attached rebuilt homes in the heart of the West End.",
                "dude-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                53.4547003,
                -113.5627506,
                2,
                2,
                1097,
                352000,
                new List<String>() { "house15.jpg" },
                "Condo",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", false }, { "Furnished", true }, { "Fireplace", true }, { "Petfriendly", true } },
                " Professionally decorated 2 bedroom, 2 bath unit",
                "The Chateaux at Whitemud Ridge is one of the most well-managed and maintained Condo buildings in Edmonton. Outstanding amenities: car wash; games room with a full movie theatre with seating for a large party!",
                "dude-3.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                53.4840762,
                -113.5798937,
                2,
                2,
                1690,
                349000,
                new List<String>() { "house16.jpg" },
                "Condo",
                new Dictionary<String, Boolean>() { { "Garage", true }, { "Backyard", false }, { "Furnished", false }, { "Fireplace", true }, { "Petfriendly", true } },
                "Spacious ground floor unit",
                "The big kitchen has lots of counter space & breakfast nook with a window overlooking the atrium. Formal dining room ideal for family gatherings",
                "dude-1.png",
                new String[] { "cosy", "homely", "pets" }
                )
            );

            App.listings.Add(new House(
                51.1609854,
                -113.9578747,
                1,
                1,
                590,
                183077,
                new List<String>() { "house17.jpg" },
                "Condo",
                new Dictionary<String, Boolean>() { { "Garage", false }, { "Backyard", false }, { "Furnished", false }, { "Fireplace", false }, { "Petfriendly", false } },
                "Single family condo",
                "Enjoy the maintenance free durability of Luxury Vinyl Plank floors and BBQ year round on your covered deck.",
                "girl-1.png",
                new String[] { "cosy", "homely", "pets" }
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
