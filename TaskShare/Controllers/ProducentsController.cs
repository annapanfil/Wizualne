using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskShare.Models;
using TaskShare.Views.Shared.Components.SearchBar;

namespace TaskShare.Controllers
{
    public class ProducentsController : Controller
    {
        private readonly DataContext _context;

        public ProducentsController(DataContext context)
        {
            _context = context;
        }

        // GET: Producents
        public async Task<IActionResult> Index(string SearchText="")
        {
            List<Producent> Producents;
            SPager SearchPager = new SPager() { Action = "Index", Controller = "Producents", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            if (SearchText != "" && SearchText != null)
            {
                Producents = _context.Producents
                    .Where(p => p.Name.Contains(SearchText))
                    .ToList();
            }
            else
            {
                Producents = _context.Producents.ToList();
            }

            return View(Producents);

            //return View(await _context.Producents.ToListAsync());
        }

        // GET: Producents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Producents == null)
            {
                return NotFound();
            }

            var producent = await _context.Producents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producent == null)
            {
                return NotFound();
            }

            return View(producent);
        }

        // GET: Producents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] Producent producent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producent);
        }

        // GET: Producents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Producents == null)
            {
                return NotFound();
            }

            var producent = await _context.Producents.FindAsync(id);
            if (producent == null)
            {
                return NotFound();
            }
            return View(producent);
        }

        // POST: Producents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] Producent producent)
        {
            if (id != producent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducentExists(producent.Id))
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
            return View(producent);
        }

        // GET: Producents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Producents == null)
            {
                return NotFound();
            }

            var producent = await _context.Producents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producent == null)
            {
                return NotFound();
            }

            return View(producent);
        }

        // POST: Producents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producents == null)
            {
                return Problem("Entity set 'DataContext.Producents'  is null.");
            }
            var producent = await _context.Producents.FindAsync(id);
            if (producent != null)
            {
                _context.Producents.Remove(producent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducentExists(int id)
        {
          return _context.Producents.Any(e => e.Id == id);
        }
    }
}
