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
    public class SizesController : Controller
    {
        private readonly DBContext _context;

        public SizesController(DBContext context)
        {
            _context = context;
        }

        // GET: Sizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sizes.ToListAsync());
        }

        // GET: Sizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sizes = await _context.Sizes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sizes == null)
            {
                return NotFound();
            }

            return View(sizes);
        }

        // GET: Sizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductID")] Sizes sizes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sizes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sizes);
        }

        // GET: Sizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sizes = await _context.Sizes.FindAsync(id);
            if (sizes == null)
            {
                return NotFound();
            }
            return View(sizes);
        }

        // POST: Sizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductID")] Sizes sizes)
        {
            if (id != sizes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sizes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SizesExists(sizes.Id))
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
            return View(sizes);
        }

        // GET: Sizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sizes = await _context.Sizes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sizes == null)
            {
                return NotFound();
            }

            return View(sizes);
        }

        // POST: Sizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sizes = await _context.Sizes.FindAsync(id);
            _context.Sizes.Remove(sizes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SizesExists(int id)
        {
            return _context.Sizes.Any(e => e.Id == id);
        }
    }
}
