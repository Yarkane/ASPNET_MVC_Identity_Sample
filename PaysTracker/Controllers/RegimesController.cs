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
    public class RegimesController : Controller
    {
        private readonly ILogger<RegimesController> _logger;
        private readonly AppDbContext _context;

        public RegimesController(AppDbContext context, ILogger<RegimesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Regimes
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Got a GET on regimes");
            return View(await _context.ListeRegimes.ToListAsync());
        }

        // GET: Regimes/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regime = await _context.ListeRegimes
                .FirstOrDefaultAsync(m => m.RegimeId == id);
            if (regime == null)
            {
                return NotFound();
            }

            return View(regime);
        }

        // GET: Regimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegimeId,Nom")] Regime regime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regime);
        }

        // GET: Regimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regime = await _context.ListeRegimes.FindAsync(id);
            if (regime == null)
            {
                return NotFound();
            }
            return View(regime);
        }

        // POST: Regimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegimeId,Nom")] Regime regime)
        {
            if (id != regime.RegimeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegimeExists(regime.RegimeId))
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
            return View(regime);
        }

        // GET: Regimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regime = await _context.ListeRegimes
                .FirstOrDefaultAsync(m => m.RegimeId == id);
            if (regime == null)
            {
                return NotFound();
            }

            return View(regime);
        }

        // POST: Regimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regime = await _context.ListeRegimes.FindAsync(id);
            _context.ListeRegimes.Remove(regime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegimeExists(int id)
        {
            return _context.ListeRegimes.Any(e => e.RegimeId == id);
        }
    }
}
