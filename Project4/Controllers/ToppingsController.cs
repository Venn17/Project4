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
    public class ToppingsController : Controller
    {
        private readonly DBContext _context;

        public ToppingsController(DBContext context)
        {
            _context = context;
        }

        // GET: Toppings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Toppings.ToListAsync());
        }

        // GET: Toppings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toppings = await _context.Toppings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toppings == null)
            {
                return NotFound();
            }

            return View(toppings);
        }

        // GET: Toppings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Toppings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductID,Status")] Toppings toppings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toppings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toppings);
        }

        // GET: Toppings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toppings = await _context.Toppings.FindAsync(id);
            if (toppings == null)
            {
                return NotFound();
            }
            return View(toppings);
        }

        // POST: Toppings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductID,Status")] Toppings toppings)
        {
            if (id != toppings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toppings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToppingsExists(toppings.Id))
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
            return View(toppings);
        }

        // GET: Toppings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toppings = await _context.Toppings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toppings == null)
            {
                return NotFound();
            }

            return View(toppings);
        }

        // POST: Toppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toppings = await _context.Toppings.FindAsync(id);
            _context.Toppings.Remove(toppings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToppingsExists(int id)
        {
            return _context.Toppings.Any(e => e.Id == id);
        }
    }
}
