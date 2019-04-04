using System.ComponentModel.DataAnnotations;
namespace MyLib
{
    public enum CuisineType
    {
        None,
        Mexican, 
        NorthIndian,
        Italian
    }
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
          [Required]
        [StringLength(255)]
        public string Address { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}

