using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiceController : ControllerBase
    {
        [HttpGet("{sides}")]
        public int Roll(int sides)
        {
            // Make a random number generator
            var randomNumberGenerator = new Random();

            // Next(sides) would make a number between 0 and just less than sides
            // so return that number plus one. Making the range from 1 to a number
            // INCLUDING the value of sides.
            var roll = randomNumberGenerator.Next(sides) + 1;

            return roll;
        }
    }
}