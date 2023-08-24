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
    public class LocalsController : ControllerBase
    {
        private readonly DBContext _context;

        public LocalsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Locals
        [HttpGet]
        public IEnumerable<Locals> GetLocals()
        {
            return _context.Locals;
        }

        // GET: api/Locals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocals([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locals = await _context.Locals.FindAsync(id);

            if (locals == null)
            {
                return NotFound();
            }

            return Ok(locals);
        }

        // PUT: api/Locals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocals([FromRoute] int id, [FromBody] Locals locals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locals.Id)
            {
                return BadRequest();
            }

            _context.Entry(locals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalsExists(id))
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

        // POST: api/Locals
        [HttpPost]
        public async Task<IActionResult> PostLocals([FromBody] Locals locals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Locals.Add(locals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocals", new { id = locals.Id }, locals);
        }

        // DELETE: api/Locals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocals([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locals = await _context.Locals.FindAsync(id);
            if (locals == null)
            {
                return NotFound();
            }

            _context.Locals.Remove(locals);
            await _context.SaveChangesAsync();

            return Ok(locals);
        }

        [Route("search")]
        public async Task<IActionResult> GetLocalsByName(string search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locals = await _context.Locals.ToListAsync();
            var data = locals.FindAll(x => x.Name.ToLower().Contains(search.ToLower()));

            if (locals == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        private bool LocalsExists(int id)
        {
            return _context.Locals.Any(e => e.Id == id);
        }
    }
}