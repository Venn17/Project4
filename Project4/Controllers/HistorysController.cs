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
    public class HistorysController : Controller
    {
        private readonly DBContext _context;

        public HistorysController(DBContext context)
        {
            _context = context;
        }

        // GET: Historys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Historys.ToListAsync());
        }

        // GET: Historys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historys = await _context.Historys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historys == null)
            {
                return NotFound();
            }

            return View(historys);
        }

        // GET: Historys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,CartID,Payment,CouponID,Status")] Historys historys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historys);
        }

        // GET: Historys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historys = await _context.Historys.FindAsync(id);
            if (historys == null)
            {
                return NotFound();
            }
            return View(historys);
        }

        // POST: Historys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,CartID,Payment,CouponID,Status")] Historys historys)
        {
            if (id != historys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorysExists(historys.Id))
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
            return View(historys);
        }

        // GET: Historys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historys = await _context.Historys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historys == null)
            {
                return NotFound();
            }

            return View(historys);
        }

        // POST: Historys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historys = await _context.Historys.FindAsync(id);
            _context.Historys.Remove(historys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorysExists(int id)
        {
            return _context.Historys.Any(e => e.Id == id);
        }
    }
}
