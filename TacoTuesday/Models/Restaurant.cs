using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TacoTuesday.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public string Telephone { get; set; }

        // The User ID of the user that created this restaurant
        public int UserId { get; set; }

        // Lat/Lng for address information
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Picture of the restaurant (https://cloudinary.com/my-images/525423523523452345.png)
        public string PhotoURL { get; set; }

        // Restaurant HAS MANY Reviews
        public List<Review> Reviews { get; set; }
    }
}