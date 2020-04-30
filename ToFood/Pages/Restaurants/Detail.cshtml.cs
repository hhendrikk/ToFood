using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToFood.Core;
using ToFood.Data;

namespace ToFood.Pages_Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }

        [TempData]
        public string Message { get; set; }
        private readonly IRestaurantData restarauntData;

        public DetailModel(IRestaurantData restarauntData)
        {
            this.restarauntData = restarauntData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = this.restarauntData.GetById(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}