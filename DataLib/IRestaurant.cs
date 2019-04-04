using System;
using System.Collections.Generic;
using System.Linq;
namespace DataLib
{
    public interface IRestaurant
    {
        IEnumerable<MyLib.Restaurant> GetAll();
        IEnumerable<MyLib.Restaurant> GetRestaurantsByName(string name);
        MyLib.Restaurant GetRestaurantsById(int id);
        MyLib.Restaurant UpdateRestaurant(MyLib.Restaurant restaurant);
        MyLib.Restaurant Add(MyLib.Restaurant restaurant);
        MyLib.Restaurant Delete(int restaurantID);
int GetCount();
        int Commit();

    }
    public class InMemoryRestaurantData : IRestaurant
    {
        List<MyLib.Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<MyLib.Restaurant>();
            restaurants.Add(new MyLib.Restaurant { Id = 1, Address = "Delhi", Name = "Cheese", Cuisine = MyLib.CuisineType.NorthIndian });
            restaurants.Add(new MyLib.Restaurant { Id = 2, Address = "Mexico", Name = "Chalupa", Cuisine = MyLib.CuisineType.Mexican });
        }
        public IEnumerable<MyLib.Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;

        }
        public IEnumerable<MyLib.Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(r.Name) || r.Name.Contains(name)
                   orderby r.Name
                   select r;

        }
        public MyLib.Restaurant GetRestaurantsById(int id)
        {
            return restaurants.Where(r => r.Id == id).FirstOrDefault();

        }
        public MyLib.Restaurant UpdateRestaurant(MyLib.Restaurant restaurant)
        {
            var rest = restaurants.Where(r => r.Id == restaurant.Id).FirstOrDefault();
            if (rest != null)
            {
                rest.Name = restaurant.Name;
                rest.Cuisine = restaurant.Cuisine;
            }
            return rest;
        }
        public MyLib.Restaurant Add(MyLib.Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            return restaurant;
        }
        public MyLib.Restaurant Delete(int restaurantID)
        {
            var rest = restaurants.Where(r => r.Id == restaurantID).FirstOrDefault();
            if (rest != null)
            {
                restaurants.Remove(rest);
            }
            return rest;
        }
        public int Commit()
        {
            return 0;
        }
        public int GetCount()
        {
          return restaurants.Count();  
        }
    }
}
