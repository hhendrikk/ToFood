using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToFood.Core;
using ToFood.Data;

namespace ToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisine { get; set; }
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper helper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper helper)
        {
            this.helper = helper;
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = this.restaurantData.GetById(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            Cuisine = helper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisine = helper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            this.restaurantData.Update(Restaurant);
            TempData["Message"] = "Restaurant saved!";

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}