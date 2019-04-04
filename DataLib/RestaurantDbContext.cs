using Microsoft.EntityFrameworkCore;
namespace DataLib
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<MyLib.Restaurant> Restaurants {get;set;}
       public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
       :base(options)
       {
           
       }
        
    }
}