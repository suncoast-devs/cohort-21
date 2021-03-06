using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geocoding.Microsoft;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TacoTuesday.Models;

namespace TacoTuesday.Controllers
{
    // All of these routes will be at the base URL:     /api/Restaurants
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case RestaurantsController to determine the URL
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        // This is the variable you use to have access to your database
        private readonly DatabaseContext _context;
        private readonly string BING_MAPS_KEY;

        // Constructor that recives a reference to your database context
        // and stores it in _context for you to use in your API methods
        public RestaurantsController(DatabaseContext context, IConfiguration config)
        {
            _context = context;
            BING_MAPS_KEY = config["BING_MAPS_KEY"];
        }

        // GET: api/Restaurants
        //
        // Returns a list of all your Restaurants
        //
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants(string filter)
        {
            // Uses the database context in `_context` to request all of the Restaurants, sort
            // them by row id and return them as a JSON array.
            if (filter == null)
            {
                return await _context.Restaurants.
                                        OrderBy(row => row.Id).
                                        Include(restaurant => restaurant.Reviews).
                                        ToListAsync();
            }
            else
            {
                // Use the filter!
                return await _context.Restaurants.
                                         Where(restaurant => restaurant.Name.ToLower().Contains(filter.ToLower())
                                                          || restaurant.Address.ToLower().Contains(filter.ToLower())).
                                         Include(restaurant => restaurant.Reviews).
                                         ToListAsync();
            }
        }

        // GET: api/Restaurants/5
        //
        // Fetches and returns a specific restaurant by finding it by id. The id is specified in the
        // URL. In the sample URL above it is the `5`.  The "{id}" in the [HttpGet("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            // Find the restaurant in the database using `FindAsync` to look it up by id
            // var restaurant = await _context.Restaurants.FindAsync(id);
            var restaurant = await _context.Restaurants.
                                                // This brings in the related reviews
                                                Include(restaurant => restaurant.Reviews).
                                                // For those reviews, this brings in the related user
                                                ThenInclude(review => review.User).
                                                Where(restaurant => restaurant.Id == id).
                                                FirstOrDefaultAsync();

            // If we didn't find anything, we receive a `null` in return
            if (restaurant == null)
            {
                // Return a `404` response to the client indicating we could not find a restaurant with this id
                return NotFound();
            }

            //  Return the restaurant as a JSON object.
            return restaurant;
        }

        // PUT: api/Restaurants/5
        //
        // Update an individual restaurant with the requested id. The id is specified in the URL
        // In the sample URL above it is the `5`. The "{id} in the [HttpPut("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        // In addition the `body` of the request is parsed and then made available to us as a Restaurant
        // variable named restaurant. The controller matches the keys of the JSON object the client
        // supplies to the names of the attributes of our Restaurant POCO class. This represents the
        // new values for the record.
        //
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            // If the ID in the URL does not match the ID in the supplied request body, return a bad request
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            // Find this restaurant by looking for the specific id
            var restaurantBelongsToUser = await _context.Restaurants.AnyAsync(restaurant => restaurant.Id == id && restaurant.UserId == GetCurrentUserId());
            if (!restaurantBelongsToUser)
            {
                // Make a custom error response
                var response = new
                {
                    status = 401,
                    errors = new List<string>() { "Not Authorized" }
                };

                // Return our error with the custom response
                return Unauthorized(response);
            }

            // Tell the database to consider everything in restaurant to be _updated_ values. When
            // the save happens the database will _replace_ the values in the database with the ones from restaurant
            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                // Try to save these changes.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Ooops, looks like there was an error, so check to see if the record we were
                // updating no longer exists.
                if (!RestaurantExists(id))
                {
                    // If the record we tried to update was already deleted by someone else,
                    // return a `404` not found
                    return NotFound();
                }
                else
                {
                    // Otherwise throw the error back, which will cause the request to fail
                    // and generate an error to the client.
                    throw;
                }
            }

            // Return a copy of the updated data
            return Ok(restaurant);
        }

        // POST: api/Restaurants
        //
        // Creates a new restaurant in the database.
        //
        // The `body` of the request is parsed and then made available to us as a Restaurant
        // variable named restaurant. The controller matches the keys of the JSON object the client
        // supplies to the names of the attributes of our Restaurant POCO class. This represents the
        // new values for the record.
        //
        [HttpPost]
        // This line forces the POST (create) to require an authorized user.
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {


            // Take the restaurant.Address and turn it into lat and lng to store in restaurant.Latitude and restaurant.Longitude    

            // Create a new geocoder
            var geocoder = new BingMapsGeocoder(BING_MAPS_KEY);

            // Request this address to be geocoded.
            var geocodedAddresses = await geocoder.GeocodeAsync(restaurant.Address);

            // ... and pick out the best address sorted by the confidence level
            var bestGeocodedAddress = geocodedAddresses.OrderBy(address => address.Confidence).LastOrDefault();

            // If we have a best geocoded address, use the latitude and longitude from that result
            if (bestGeocodedAddress != null)
            {
                restaurant.Latitude = bestGeocodedAddress.Coordinates.Latitude;
                restaurant.Longitude = bestGeocodedAddress.Coordinates.Longitude;
            }



            // Ignore whatever the client (user) MIGHT have said the UserId is for this
            // new restaurant. I'll set the UserId to the *SECURE* GetCurrentUserId.
            //
            // This ensures the correct user is associated to this restaurant!
            restaurant.UserId = GetCurrentUserId();

            // Indicate to the database context we want to add this new record
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();

            // Return a response that indicates the object was created (status code `201`) and some additional
            // headers with details of the newly created object.
            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurants/5
        //
        // Deletes an individual restaurant with the requested id. The id is specified in the URL
        // In the sample URL above it is the `5`. The "{id} in the [HttpDelete("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            // Find this restaurant by looking for the specific id
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                // There wasn't a restaurant with that id so return a `404` not found
                return NotFound();
            }

            // If the user from the database doesn't match the user from our authentication
            if (restaurant.UserId != GetCurrentUserId())
            {
                // Make a custom error response
                var response = new
                {
                    status = 401,
                    errors = new List<string>() { "Not Authorized" }
                };

                // Return our error with the custom response
                return Unauthorized(response);
            }

            // Tell the database we want to remove this record
            _context.Restaurants.Remove(restaurant);

            // Tell the database to perform the deletion
            await _context.SaveChangesAsync();

            // Return a copy of the deleted data
            return Ok(restaurant);
        }

        // Private helper method that looks up an existing restaurant by the supplied id
        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(restaurant => restaurant.Id == id);
        }

        // Private helper method to get the JWT claim related to the user ID
        private int GetCurrentUserId()
        {
            // Get the User Id from the claim and then parse it as an integer.
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
