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
    public class LoginedsController : ControllerBase
    {
        private readonly DBContext _context;

        public LoginedsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Logineds
        [HttpGet]
        public IEnumerable<Logined> GetLogineds()
        {
            return _context.Logineds;
        }

        // GET: api/Logineds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogined([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Logineds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogined([FromRoute] int id, [FromBody] Logined logined)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logined.Id)
            {
                return BadRequest();
            }

            _context.Entry(logined).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginedExists(id))
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

        // POST: api/Logineds
        [HttpPost]
        public async Task<IActionResult> PostLogined([FromBody] Logined logined)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Logineds.Add(logined);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogined", new { id = logined.Id }, logined);
        }

        // DELETE: api/Logineds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogined([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logined = await _context.Logineds.FindAsync(id);
            if (logined == null)
            {
                return NotFound();
            }

            _context.Logineds.Remove(logined);
            await _context.SaveChangesAsync();

            return Ok(logined);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            var logined = await _context.Logineds.ToListAsync();
            if (logined == null)
            {
                return NotFound();
            }
            foreach (var item in logined)
            {
                _context.Logineds.Remove(item);
            }
            await _context.SaveChangesAsync();
            return Ok(logined);
        }

        private bool LoginedExists(int id)
        {
            return _context.Logineds.Any(e => e.Id == id);
        }
    }
}