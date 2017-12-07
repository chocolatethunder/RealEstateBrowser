using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBrowser.Models
{
    class User
    {
        public Dictionary<Guid, House> favs { get; }
        public Dictionary<Guid, House> compare { get; }

        public User()
        {
            this.favs = new Dictionary<Guid, House>();
            this.compare = new Dictionary<Guid, House>();
        }

        public Boolean addToFavs(House house)
        {
            if (!this.favs.ContainsKey(house._id))
            {
                this.favs.Add(house._id, house);
                return true;
            }           
            return false;
        }

        public Boolean addToCompare(House house)
        {
            if (this.compare.Count() < 3 && !this.compare.ContainsKey(house._id))
            {
                this.compare.Add(house._id, house);
                return true;
            }
            return false;
        }

        public List<House> getFavs()
        {
            var result = new List<House>();
            foreach (KeyValuePair<Guid, House> data in favs)
            {
                result.Add(data.Value);
            }
            return result;
        }

        public void clearData()
        {
            this.favs.Clear();
            this.compare.Clear();
        }
    }
}
