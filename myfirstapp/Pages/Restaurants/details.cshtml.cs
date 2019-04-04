using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib;
using DataLib;

namespace myfirstapp.Pages.Restaurants
{
    public class detailsModel : PageModel
    {
        public MyLib.Restaurant Restaurant { get; set; }
        private readonly IRestaurant restaurantData;
        [TempData]
        public string Message { get; set; }
        public detailsModel(IRestaurant restaurantData)
        {
            this.restaurantData = restaurantData;

        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantsById(restaurantId);
            if (Restaurant != null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./notfound");
            }


        }
    }
}