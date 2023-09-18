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
    public class SizesController : ControllerBase
    {
        private readonly DBContext _context;

        public SizesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Sizes
        [HttpGet]
        public IEnumerable<Sizes> GetSizes()
        {
            return _context.Sizes;
        }

        // GET: api/Sizes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSizes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sizes = await _context.Sizes.FindAsync(id);

            if (sizes == null)
            {
                return NotFound();
            }

            return Ok(sizes);
        }

        // PUT: api/Sizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizes([FromRoute] int id, [FromBody] Sizes sizes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sizes.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizesExists(id))
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

        // POST: api/Sizes
        [HttpPost]
        public async Task<IActionResult> PostSizes([FromBody] Sizes sizes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sizes.Add(sizes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizes", new { id = sizes.Id }, sizes);
        }

        // DELETE: api/Sizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sizes = await _context.Sizes.FindAsync(id);
            if (sizes == null)
            {
                return NotFound();
            }

            _context.Sizes.Remove(sizes);
            await _context.SaveChangesAsync();

            return Ok(sizes);
        }

        [HttpGet]
        [Route("getProduct")]
        public async Task<IActionResult> GetSizesByProduct([FromRoute] int productID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sizes = await _context.Sizes.ToListAsync();
            var data = sizes.FindAll(x => x.ProductID == productID);

            if (sizes == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetSizesByProName(string search, int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var c = await _context.Sizes.ToListAsync();
            var data = c.ToList();
            if (search == "" || search == null)
            {
                if (productId == 0)
                {

                }
                else
                {
                    data = c.FindAll(x => x.ProductID == productId).ToList();
                }
            }
            else
            {
                if (productId == 0)
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

        private bool SizesExists(int id)
        {
            return _context.Sizes.Any(e => e.Id == id);
        }
    }
}