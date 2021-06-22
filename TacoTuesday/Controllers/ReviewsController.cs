using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TacoTuesday.Models;

namespace TacoTuesday.Controllers
{
    // All of these routes will be at the base URL:     /api/Reviews
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case ReviewsController to determine the URL
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        // This is the variable you use to have access to your database
        private readonly DatabaseContext _context;

        // Constructor that recives a reference to your database context
        // and stores it in _context for you to use in your API methods
        public ReviewsController(DatabaseContext context)
        {
            _context = context;
        }

        // POST: api/Reviews
        //
        // Creates a new review in the database.
        //
        // The `body` of the request is parsed and then made available to us as a Review
        // variable named review. The controller matches the keys of the JSON object the client
        // supplies to the names of the attributes of our Review POCO class. This represents the
        // new values for the record.
        //
        [HttpPost]
        // This line forces the POST (create) to require an authorized user.
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            // Ignore whatever the client (user) MIGHT have said the UserId is for this
            // new review. I'll set the UserId to the *SECURE* GetCurrentUserId.
            //
            // This ensures the correct user is associated to this review!
            review.UserId = GetCurrentUserId();

            // Indicate to the database context we want to add this new record
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            // Return a response that indicates the object was created (status code `201`) and some additional
            // headers with details of the newly created object.
            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        // Private helper method to get the JWT claim related to the user ID
        private int GetCurrentUserId()
        {
            // Get the User Id from the claim and then parse it as an integer.
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
