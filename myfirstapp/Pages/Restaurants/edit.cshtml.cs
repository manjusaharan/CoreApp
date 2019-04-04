using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLib;
using MyLib;

namespace myfirstapp.Pages.Restaurants
{
    public class editModel : PageModel
    {
        private readonly IRestaurant restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public MyLib.Restaurant Restaurant { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public editModel(IRestaurant restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantsById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();

            }
            if (Restaurant == null)
            {
                return RedirectToPage("./notfound");
            }
            else
            {
                return Page();
            }

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Restaurant.Id < 1)
                    Restaurant = restaurantData.Add(Restaurant);
                else
                    Restaurant = restaurantData.UpdateRestaurant(Restaurant);
                restaurantData.Commit();
                return RedirectToPage("./details", new { restaurantId = Restaurant.Id });
            }
            TempData["Message"]="Restaurant saved";
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }
    }
}