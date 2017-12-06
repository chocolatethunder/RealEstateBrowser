using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace RealEstateBrowser
{
    class Search
    {
        private MapLocationFinderResult locationData;
        private int bedrooms;
        private int bathrooms;
        private int budgetHigh;
        private int budgetLow;
        private string houseType;
        private List<string> previousSearches = new List<string>();

        public Search()
        {
            // Get auto location
        }

        public async Task<GeolocationAccessStatus> getGPSAccessStatus()
        {
            return await Geolocator.RequestAccessAsync();
        }

        public async Task<MapLocationFinderResult> getLocationData()
        {
            Geolocator geoLocator = new Geolocator { DesiredAccuracy = PositionAccuracy.Default };
            Geoposition pos = await geoLocator.GetGeopositionAsync();
            BasicGeoposition coords = new BasicGeoposition();
            coords.Latitude = pos.Coordinate.Point.Position.Latitude;
            coords.Longitude = pos.Coordinate.Point.Position.Longitude;
            Geopoint coordsToReverse = new Geopoint(coords);
            this.locationData = await MapLocationFinder.FindLocationsAtAsync(coordsToReverse);
            return this.locationData;
        }

        public async Task<MapLocationFinderResult> getLocDataFromCity(string address)
        {
            this.locationData = await MapLocationFinder.FindLocationsAsync(address, null);
            return this.locationData;
        }

        public List<House> getSearchResults()
        {
            return App.listings;
        }

        public string getSearchCity()
        {
            if (this.locationData != null && this.locationData.Status == MapLocationFinderStatus.Success)
            {
                return this.locationData.Locations[0].Address.Town;
            }
            return null;
        }

        public void addToSearchHistory(string searchquery)
        {
            this.previousSearches.Add(searchquery);
        }

        public List<string> getSearchHistory()
        {
            return this.previousSearches;
        }

        public double getLon()
        {
            if (this.locationData != null && this.locationData.Status == MapLocationFinderStatus.Success)
            {
                return this.locationData.Locations[0].Point.Position.Longitude;
            }
            return -1;
        }

        public double getLat()
        {
            if (this.locationData != null && this.locationData.Status == MapLocationFinderStatus.Success)
            {
                return this.locationData.Locations[0].Point.Position.Latitude;
            }
            return -1;
        }

        public void setHouseType(string type)
        {
            this.houseType = type;
        }

        public void setBathrooms(int bathrooms)
        {
            this.bathrooms = bathrooms;
        }

        public int getBathrooms()
        {
            return this.bathrooms;
        }

        public void setBedrooms(int bedrooms)
        {
            this.bedrooms = bedrooms;
        }

        public int getBedrooms()
        {
            return this.bedrooms;
        }

        public void setBudgetFrom(int budget)
        {
            this.budgetLow = budget;
        }

        public int getBudgetFrom()
        {
            return this.budgetLow;
        }

        public void setBudgetTo(int budget)
        {
            this.budgetHigh = budget;
        }

        public int getBudgetTo()
        {
            return this.budgetHigh;
        }

    }

}
