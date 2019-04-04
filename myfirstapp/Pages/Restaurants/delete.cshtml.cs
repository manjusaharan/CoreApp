using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataLib;
using MyLib;

namespace myfirstapp.Pages.Restaurants
{
    public class deleteModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        private readonly IRestaurant restaurantData;
        public deleteModel(IRestaurant restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantsById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./notfound");
            }
            else
                return Page();
        }
        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();
            if (Restaurant == null)
            {
                return RedirectToPage("./notfound");
            }
            else
            {
                TempData["Message"] = $"{ Restaurant.Name } is deleted";
                return RedirectToPage("./List");
            }

        }
    }
}