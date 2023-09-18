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
    public class ToppingsController : ControllerBase
    {
        private readonly DBContext _context;

        public ToppingsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Toppings
        [HttpGet]
        public IEnumerable<Toppings> GetToppings()
        {
            return _context.Toppings;
        }

        // GET: api/Toppings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToppings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toppings = await _context.Toppings.FindAsync(id);

            if (toppings == null)
            {
                return NotFound();
            }

            return Ok(toppings);
        }

        // PUT: api/Toppings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToppings([FromRoute] int id, [FromBody] Toppings toppings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toppings.Id)
            {
                return BadRequest();
            }

            _context.Entry(toppings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToppingsExists(id))
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

        // POST: api/Toppings
        [HttpPost]
        public async Task<IActionResult> PostToppings([FromBody] Toppings toppings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Toppings.Add(toppings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToppings", new { id = toppings.Id }, toppings);
        }

        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToppings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toppings = await _context.Toppings.FindAsync(id);
            if (toppings == null)
            {
                return NotFound();
            }

            _context.Toppings.Remove(toppings);
            await _context.SaveChangesAsync();

            return Ok(toppings);
        }

        [HttpGet] 
        [Route("getProduct")]
        public async Task<IActionResult> GetToppingsByProduct([FromRoute] int productID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toppings = await _context.Toppings.ToListAsync();
            var data = toppings.FindAll(x => x.ProductID == productID);

            if (toppings == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetToppingByProName(string search,int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var c = await _context.Toppings.ToListAsync();
            var data = c.ToList();
            if(search == "" || search == null)
            {
                if(productId == 0)
                {

                }
                else
                {
                    data = c.FindAll(x => x.ProductID == productId).ToList();
                }
            }
            else
            {
                if(productId == 0)
                {
                    data = c.FindAll(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                }
                else
                {
                    data = c.FindAll(x => x.Name.ToLower().Contains(search.ToLower()) & x.ProductID == productId).ToList();
                }
            }
            if (c == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        private bool ToppingsExists(int id)
        {
            return _context.Toppings.Any(e => e.Id == id);
        }
    }
}