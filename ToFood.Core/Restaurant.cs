using System.ComponentModel.DataAnnotations;

namespace ToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MinLength(3), StringLength(80)]
        public string Name { get; set; }

        [Required, MinLength(3), StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}