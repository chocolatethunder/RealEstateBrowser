using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Maps;

namespace RealEstateBrowser
{
    class House
    {
        public double _longitude { get; }
        public double _latitude { get; }
        public int _bedrooms { get; }
        public int _bathrooms { get; }
        public float _area { get; }
        public int _price { get; }
        public List<String> _images { get; }
        public String _propertyType { get; }
        public Dictionary<String, Boolean> _features { get; }
        public String _title { get; set; }
        public String _description { get; set; }

        public House(
            double latitude,
            double longitude,
            int bedrooms,
            int bathrooms,
            float area,
            int price,
            List<String> images,
            String propertyType,
            Dictionary<String, Boolean> features,
            String title,
            String description
        )
        {
            this._latitude = latitude;
            this._longitude = longitude;            
            this._bedrooms = bedrooms;
            this._bathrooms = bathrooms;
            this._area = area;
            this._price = price;
            this._images = images.ToList();
            this._propertyType = propertyType;
            this._features = features.ToDictionary(entry => entry.Key, entry => entry.Value);
            this._title = title;
            this._description = description;
        }

    }

}
