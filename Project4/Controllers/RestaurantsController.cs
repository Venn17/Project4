using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project4.Models;
using Project4.Services;

namespace Project4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly DBContext _context;

        public RestaurantsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public IEnumerable<Restaurants> GetRestaurants()
        {
            return _context.Restaurants;
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurants([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurants = await _context.Restaurants.FindAsync(id);

            if (restaurants == null)
            {
                return NotFound();
            }

            return Ok(restaurants);
        }

        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurants([FromRoute] int id, [FromBody] Restaurants restaurants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurants.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        [HttpPost]
        public async Task<IActionResult> PostRestaurants([FromBody] Restaurants restaurants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Restaurants.Add(restaurants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurants", new { id = restaurants.Id }, restaurants);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurants([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurants = await _context.Restaurants.FindAsync(id);
            if (restaurants == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurants);
            await _context.SaveChangesAsync();

            return Ok(restaurants);
        }

        private bool RestaurantsExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}