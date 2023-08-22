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
    public class CouponsController : Controller
    {
        private readonly DBContext _context;

        public CouponsController(DBContext context)
        {
            _context = context;
        }

        // GET: Coupons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupons.ToListAsync());
        }

        // GET: Coupons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupons = await _context.Coupons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coupons == null)
            {
                return NotFound();
            }

            return View(coupons);
        }

        // GET: Coupons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Percent,Status")] Coupons coupons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coupons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coupons);
        }

        // GET: Coupons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupons = await _context.Coupons.FindAsync(id);
            if (coupons == null)
            {
                return NotFound();
            }
            return View(coupons);
        }

        // POST: Coupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Percent,Status")] Coupons coupons)
        {
            if (id != coupons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coupons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponsExists(coupons.Id))
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
            return View(coupons);
        }

        // GET: Coupons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupons = await _context.Coupons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coupons == null)
            {
                return NotFound();
            }

            return View(coupons);
        }

        // POST: Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coupons = await _context.Coupons.FindAsync(id);
            _context.Coupons.Remove(coupons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouponsExists(int id)
        {
            return _context.Coupons.Any(e => e.Id == id);
        }
    }
}
