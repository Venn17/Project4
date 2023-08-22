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
    public class LocalsController : Controller
    {
        private readonly DBContext _context;

        public LocalsController(DBContext context)
        {
            _context = context;
        }

        // GET: Locals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locals.ToListAsync());
        }

        // GET: Locals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locals = await _context.Locals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locals == null)
            {
                return NotFound();
            }

            return View(locals);
        }

        // GET: Locals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Locals locals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locals);
        }

        // GET: Locals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locals = await _context.Locals.FindAsync(id);
            if (locals == null)
            {
                return NotFound();
            }
            return View(locals);
        }

        // POST: Locals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Locals locals)
        {
            if (id != locals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalsExists(locals.Id))
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
            return View(locals);
        }

        // GET: Locals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locals = await _context.Locals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locals == null)
            {
                return NotFound();
            }

            return View(locals);
        }

        // POST: Locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locals = await _context.Locals.FindAsync(id);
            _context.Locals.Remove(locals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalsExists(int id)
        {
            return _context.Locals.Any(e => e.Id == id);
        }
    }
}
