using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project4.Models;
using Project4.Services;

namespace Project4.Controllers
{
    public class LoginedsController : Controller
    {
        private readonly DBContext _context;

        public LoginedsController(DBContext context)
        {
            _context = context;
        }

        // GET: Logineds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logineds.ToListAsync());
        }

        // GET: Logineds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logined = await _context.Logineds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logined == null)
            {
                return NotFound();
            }

            return View(logined);
        }

        // GET: Logineds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logineds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID")] Logined logined)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logined);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logined);
        }

        // GET: Logineds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logined = await _context.Logineds.FindAsync(id);
            if (logined == null)
            {
                return NotFound();
            }
            return View(logined);
        }

        // POST: Logineds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID")] Logined logined)
        {
            if (id != logined.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logined);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginedExists(logined.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(logined);
        }

        // GET: Logineds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logined = await _context.Logineds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logined == null)
            {
                return NotFound();
            }

            return View(logined);
        }

        // POST: Logineds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logined = await _context.Logineds.FindAsync(id);
            _context.Logineds.Remove(logined);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginedExists(int id)
        {
            return _context.Logineds.Any(e => e.Id == id);
        }
    }
}
