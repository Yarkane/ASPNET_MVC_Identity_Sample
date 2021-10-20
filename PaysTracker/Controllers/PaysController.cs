using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaysTracker.Data;
using PaysTracker.Models;

namespace PaysTracker.Controllers
{
    [Authorize]
    public class PaysController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PaysController> _logger;

        public PaysController(AppDbContext context, ILogger<PaysController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Pays
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Got a GET on Pays");
            var appDbContext = _context.ListePays.Include(p => p.Regime);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Pays/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pays = await _context.ListePays
                .Include(p => p.Regime)
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (pays == null)
            {
                return NotFound();
            }

            return View(pays);
        }

        // GET: Pays/Create
        public IActionResult Create()
        {
            ViewData["RegimeId"] = new SelectList(_context.ListeRegimes, "RegimeId", "Nom");
            return View();
        }

        // POST: Pays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Dirigeant,Surface,Population,RegimeId")] Pays pays)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegimeId"] = new SelectList(_context.ListeRegimes, "RegimeId", "Nom", pays.RegimeId);
            return View(pays);
        }

        // GET: Pays/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pays = await _context.ListePays.FindAsync(id);
            if (pays == null)
            {
                return NotFound();
            }
            ViewData["RegimeId"] = new SelectList(_context.ListeRegimes, "RegimeId", "Nom", pays.RegimeId);
            return View(pays);
        }

        // POST: Pays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nom,Dirigeant,Surface,Population,RegimeId")] Pays pays)
        {
            if (id != pays.Nom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaysExists(pays.Nom))
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
            ViewData["RegimeId"] = new SelectList(_context.ListeRegimes, "RegimeId", "Nom", pays.RegimeId);
            return View(pays);
        }

        // GET: Pays/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pays = await _context.ListePays
                .Include(p => p.Regime)
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (pays == null)
            {
                return NotFound();
            }

            return View(pays);
        }

        // POST: Pays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pays = await _context.ListePays.FindAsync(id);
            _context.ListePays.Remove(pays);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaysExists(string id)
        {
            return _context.ListePays.Any(e => e.Nom == id);
        }
    }
}
