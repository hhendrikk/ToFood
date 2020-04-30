using System.Collections.Generic;
using System.Linq;
using ToFood.Core;

namespace ToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int restaurantId);
        Restaurant Update(Restaurant updateRestaurant);
    }

    public class MemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public MemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Adriana Pizza", Location = "Gama City", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 2, Name = "Valentina Pizza", Location = "Tagua City", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "Hendrik Pizza", Location = "Brasolia City", Cuisine = CuisineType.Indian },
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in this.restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name ascending
                   select r;
        }

        public Restaurant GetById(int restaurantId)
        {
            return this.restaurants.SingleOrDefault(_ => _.Id == restaurantId);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = this.restaurants.SingleOrDefault(_ => _.Id == updateRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }

            return restaurant;
        }
    }
}