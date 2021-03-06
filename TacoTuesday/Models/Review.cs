using System;

namespace TacoTuesday.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public int Stars { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public int RestaurantId { get; set; }

        // The User ID of the user that created this review
        public int UserId { get; set; }

        // The related User object
        public User User { get; set; }
    }
}