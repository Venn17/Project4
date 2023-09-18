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
    public class CouponsController : ControllerBase
    {
        private readonly DBContext _context;

        public CouponsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Coupons
        [HttpGet]
        public IEnumerable<Coupons> GetCoupons()
        {
            return _context.Coupons;
        }

        // GET: api/Coupons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoupons([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coupons = await _context.Coupons.FindAsync(id);

            if (coupons == null)
            {
                return NotFound();
            }

            return Ok(coupons);
        }

        // PUT: api/Coupons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoupons([FromRoute] int id, [FromBody] Coupons coupons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupons.Id)
            {
                return BadRequest();
            }

            _context.Entry(coupons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponsExists(id))
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

        // POST: api/Coupons
        [HttpPost]
        public async Task<IActionResult> PostCoupons([FromBody] Coupons coupons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Coupons.Add(coupons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoupons", new { id = coupons.Id }, coupons);
        }

        // DELETE: api/Coupons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupons([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coupons = await _context.Coupons.FindAsync(id);
            if (coupons == null)
            {
                return NotFound();
            }

            _context.Coupons.Remove(coupons);
            await _context.SaveChangesAsync();

            return Ok(coupons);
        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetCouponByName(string search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var c = await _context.Coupons.ToListAsync();
            var data = c.FindAll(x => x.Name.ToLower().Contains(search.ToLower()));

            if (c == null)
            {
                return NotFound();
            }

            return Ok(data);
        }


        private bool CouponsExists(int id)
        {
            return _context.Coupons.Any(e => e.Id == id);
        }
    }
}