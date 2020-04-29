using System.Collections.Generic;
using System.Linq;
using ToFood.Core;

namespace ToFood.Data
{
  public interface IRestaurantData
  {
    IEnumerable<Restaurant> GetRestaurantByName(string name);
  }

  public class MemoryRestaurantData : IRestaurantData
  {
    private readonly List<Restaurant> restaurants;

    public MemoryRestaurantData()
    {
      this.restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Adriana Pizza", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 2, Name = "Valentina Pizza", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "Hendrik Pizza", Cuisine = CuisineType.Indian },
            };
    }

    public IEnumerable<Restaurant> GetRestaurantByName(string name)
    {
      return from r in this.restaurants
             where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
             orderby r.Name ascending
             select r;
    }
  }
}