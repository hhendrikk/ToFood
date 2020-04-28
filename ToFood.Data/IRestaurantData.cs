using System.Collections.Generic;
using System.Linq;
using ToFood.Core;

namespace ToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class MemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public MemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Restaurant 1", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 2, Name = "Restaurant 2", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "Restaurant 3", Cuisine = CuisineType.Indian },
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in this.restaurants
                   orderby r.Name ascending
                   select r;
        }
    }
}