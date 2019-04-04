using Microsoft.AspNetCore.Mvc;
using DataLib;
namespace myfirstapp.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurant restaurantData;
        public RestaurantCountViewComponent(IRestaurant restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCount();
            return View(count);
        }
    }
}