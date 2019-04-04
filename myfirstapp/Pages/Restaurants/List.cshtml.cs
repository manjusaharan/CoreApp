using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using DataLib;

namespace myfirstapp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurant restaurantData;
        public string Message { get; set; }
        [BindProperty(SupportsGet=true)]
         public string SearchTerm { get; set; }
        public IEnumerable<MyLib.Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration config, IRestaurant restaurantData)
        {

            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Message = this.config["Message"];
            if(string.IsNullOrEmpty(SearchTerm))
           Restaurants=  this.restaurantData.GetAll();
           else 
            Restaurants=  this.restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
