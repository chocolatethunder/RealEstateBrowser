using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace RealEstateBrowser.Models
{
    class Search
    {
        private MapLocationFinderResult locationData;
        private int bedroomsLow;
        private int bedroomsHigh;
        private int bathroomsLow;
        private int bathroomsHigh;
        private int budgetHigh;
        private int budgetLow;
        private string houseType;
        private List<String> previousSearches = new List<String>();
        Dictionary<String, Boolean> features = new Dictionary<string, bool>() { { "Garage", false }, { "Backyard", false }, { "Furnished", false }, { "Fireplace", false }, { "Petfriendly", false } };
        private float sqftFrom = 0;
        private float sqftTo = 10000;
        private List<String> searchtags = new List<string>();

        public Boolean complete { get; set; }

        public Search()
        {
            this.complete = false;
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

        public bool Between(double number, double min, double max)
        {
            return number >= min && number <= max;
        }

        public bool Between(int number, int min, int max)
        {
            return number >= min && number <= max;
        }

        public List<House> getBasicSearchResults()
        {
            List<House> results = new List<House>();

            foreach (House listing in App.listings)
            {
                if (this.Between(listing._latitude, this.locationData.Locations[0].Point.Position.Latitude - 0.5, this.locationData.Locations[0].Point.Position.Latitude + 0.5))
                {
                    results.Add(listing);
                }
            }
            return results;
        }

        public List<House> getSearchResults()
        {
            List<House> results = new List<House>();

            // Perform filter here
            foreach (House listing in this.getBasicSearchResults())
            {               
                if (this.Between(listing._price, this.budgetLow, this.budgetHigh) || (this.budgetHigh == 1000000 && listing._price >= 1000000))
                {
                    if (this.Between(listing._bathrooms, this.bathroomsLow, this.bathroomsHigh) && this.Between(listing._bedrooms, this.bedroomsLow, this.bedroomsHigh))
                    {
                        if (listing._propertyType.Equals(this.houseType))
                        {
                            results.Add(listing);
                        }                           
                    }                            
                }                
            }
            return results;
        }

        public List<House> getAdvancedResults()
        {
            List<House> results = new List<House>();            

            foreach (House listing in this.getSearchResults())
            {
                if (this.sameDictionary(this.features, listing._features) && this.Between(listing._area, this.sqftFrom, this.sqftTo))
                {
                    if (!this.searchtags.Any())
                    {
                        results.Add(listing);
                        
                    } else
                    {
                        foreach (String tag in this.searchtags)
                        {
                            if (listing._tags.Contains(tag))
                            {
                                results.Add(listing);
                            }
                        }
                    }
                    
                }
            }
            return results;
        }

        public Boolean sameDictionary (Dictionary<String,Boolean> x, Dictionary<String, Boolean> y)
        {
            if (null == y)
            {
                return null == x;
            }                
            if (null == x)
            {
                return false;
            }                
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }                
            if (x.Count != y.Count)
            {
                return false;
            } 
            foreach (String k in x.Keys)
            {
                if (x[k] == true && !x[k].Equals(y[k])) {
                    return false;
                }
            }     
            return true;
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
            this.bathroomsLow = this.bathroomsHigh = bathrooms;
        }

        public void setBathroomMin(int bathrooms)
        {
            this.bathroomsLow = bathrooms;
        }

        public void setBathroomMax(int bathrooms)
        {
            this.bathroomsHigh = bathrooms;
        }

        public int getBathrooms()
        {
            return this.bathroomsLow;
        }

        public void setBedrooms(int bedrooms)
        {
            this.bedroomsLow = this.bedroomsHigh = bedrooms;
        }

        public void setBedroomMin(int bedrooms)
        {
            this.bedroomsLow = bedrooms;
        }

        public void setBedroomMax(int bedrooms)
        {
            this.bedroomsHigh = bedrooms;
        }

        public int getBedrooms()
        {
            return this.bedroomsLow;
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

        public void setSquareFtLow(float area)
        {
            this.sqftFrom = area;
        }
        public void setSquareFtHigh(float area)
        {
            this.sqftTo = area;
        }
        public float getSquareFtLow()
        {
            return this.sqftFrom;
        }
        public float getSquareFtHigh()
        {
            return this.sqftTo;
        }

        public void feature (String feat, Boolean value)
        {
            this.features[feat] = value;
        }

        public void setSearchTags(List<String> tags)
        {
            if (tags != null && tags.Count() > 0)
            {
                this.searchtags = tags;
            }
            else if (tags == null)
            {
                this.searchtags.Clear();
            }

        }

    }

}
