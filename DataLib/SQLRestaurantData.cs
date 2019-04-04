 using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLib{
 public class SQLRestaurantData : IRestaurant
    {
       private readonly DataLib.RestaurantDbContext dbContext;

        public SQLRestaurantData(DataLib.RestaurantDbContext dbContext)
        {
           this.dbContext = dbContext;
              }
        public IEnumerable<MyLib.Restaurant> GetAll()
        {
            return from r in dbContext.Restaurants
                   orderby r.Name
                   select r;

        }
        public IEnumerable<MyLib.Restaurant> GetRestaurantsByName(string name)
        {
            return from r in dbContext.Restaurants
                   where string.IsNullOrEmpty(r.Name) || r.Name.Contains(name)
                   orderby r.Name
                   select r;

        }
        public MyLib.Restaurant GetRestaurantsById(int id)
        {
            return dbContext.Restaurants.Find(id);

        }
        public MyLib.Restaurant UpdateRestaurant(MyLib.Restaurant restaurant)
        {
            var entity = dbContext.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
          
            return restaurant;
        }
         public MyLib.Restaurant Add(MyLib.Restaurant restaurant)
        {
           dbContext.Add(restaurant);
            return restaurant;
        }
         public MyLib.Restaurant Delete(int restaurantID)
        {
           var rest = dbContext.Restaurants.Where(r => r.Id == restaurantID).FirstOrDefault();
            if (rest != null)
            {
               dbContext.Restaurants.Remove(rest);
            }
            return rest;
        }
        public int Commit()
        {
            dbContext.SaveChanges();
            return 1;
        }
          public int GetCount()
        {
          return dbContext.Restaurants.Count();  
        }
    }
}