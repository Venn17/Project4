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
    public class HistorysController : ControllerBase
    {
        private readonly DBContext _context;

        public HistorysController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Historys
        [HttpGet]
        public IEnumerable<Historys> GetHistorys()
        {
            return _context.Historys;
        }

        // GET: api/Historys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistorys([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historys = await _context.Historys.FindAsync(id);

            if (historys == null)
            {
                return NotFound();
            }

            return Ok(historys);
        }

        // PUT: api/Historys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorys([FromRoute] int id, [FromBody] Historys historys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historys.Id)
            {
                return BadRequest();
            }

            _context.Entry(historys).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorysExists(id))
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

        // POST: api/Historys
        [HttpPost]
        public async Task<IActionResult> PostHistorys([FromBody] Historys historys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Historys.Add(historys);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorys", new { id = historys.Id }, historys);
        }

        // DELETE: api/Historys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorys([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historys = await _context.Historys.FindAsync(id);
            if (historys == null)
            {
                return NotFound();
            }

            _context.Historys.Remove(historys);
            await _context.SaveChangesAsync();

            return Ok(historys);
        }

        private bool HistorysExists(int id)
        {
            return _context.Historys.Any(e => e.Id == id);
        }
    }
}