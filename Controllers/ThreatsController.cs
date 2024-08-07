using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DefenseSim.Data;
using DefenseSim.ModelsAttack;

namespace DefenseSim.Controllers
{
    public class ThreatsController : Controller
    {
        private readonly AttackDbContext _context;

        public ThreatsController(AttackDbContext context)
        {
            _context = context;
        }

        // GET: Threats
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.threats.Include(t => t.Destination).Include(t => t.Origin).Include(t => t.Response).Include(t => t.Weapon);
            return View(await appDbContext.ToListAsync());
        }


        // GET: Threats/Create
        public IActionResult Create()
        {
            ViewData["DestinationId"] = new SelectList(_context.locations, "Id", "Name");
            ViewData["OriginId"] = new SelectList(_context.locations, "Id", "Name");
            ViewData["ResponseId"] = new SelectList(_context.responses, "Id", "Id");
            ViewData["WeaponId"] = new SelectList(_context.weapons, "Id", "Id");
            return View();
        }

        // POST: Threats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OriginId,DestinationId,WeaponId,BarrageSize,BarrageCount,BarrageDelay")] Threat threat)
        {
            threat.Origin = _context.locations.Find(threat.OriginId);
            threat.Destination = _context.locations.Find(threat.DestinationId);
            threat.Weapon = _context.weapons.Find(threat.WeaponId);
            ModelState.Remove("Origin");
            ModelState.Remove("Destination");
            ModelState.Remove("Weapon");
            if (ModelState.IsValid)
            {
                _context.Add(threat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinationId"] = new SelectList(_context.locations, "Id", "Name", threat.DestinationId);
            ViewData["OriginId"] = new SelectList(_context.locations, "Id", "Name", threat.OriginId);
            ViewData["ResponseId"] = new SelectList(_context.responses, "Id", "Id", threat.ResponseId);
            ViewData["WeaponId"] = new SelectList(_context.weapons, "Id", "Id", threat.WeaponId);
            return View(threat);
        }

        // GET: Threats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threat = await _context.threats.FindAsync(id);
            if (threat == null)
            {
                return NotFound();
            }
            ViewData["DestinationId"] = new SelectList(_context.locations, "Id", "Name", threat.DestinationId);
            ViewData["OriginId"] = new SelectList(_context.locations, "Id", "Name", threat.OriginId);
            ViewData["ResponseId"] = new SelectList(_context.responses, "Id", "Id", threat.ResponseId);
            ViewData["WeaponId"] = new SelectList(_context.weapons, "Id", "Id", threat.WeaponId);
            return View(threat);
        }

        // POST: Threats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OriginId,DestinationId,LaunchTime,WeaponId,BarrageSize,BarrageCount,BarrageDelay,ResponseId")] Threat threat)
        {
            if (id != threat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreatExists(threat.Id))
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
            ViewData["DestinationId"] = new SelectList(_context.locations, "Id", "Name", threat.DestinationId);
            ViewData["OriginId"] = new SelectList(_context.locations, "Id", "Name", threat.OriginId);
            ViewData["ResponseId"] = new SelectList(_context.responses, "Id", "Id", threat.ResponseId);
            ViewData["WeaponId"] = new SelectList(_context.weapons, "Id", "Id", threat.WeaponId);
            return View(threat);
        }

        // GET: Threats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threat = await _context.threats
                .Include(t => t.Destination)
                .Include(t => t.Origin)
                .Include(t => t.Response)
                .Include(t => t.Weapon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (threat == null)
            {
                return NotFound();
            }

            return View(threat);
        }

        // POST: Threats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var threat = await _context.threats.FindAsync(id);
            if (threat != null)
            {
                _context.threats.Remove(threat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreatExists(int id)
        {
            return _context.threats.Any(e => e.Id == id);
        }
    }
}
