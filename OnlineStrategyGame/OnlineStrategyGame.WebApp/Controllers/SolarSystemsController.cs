using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStrategyGame.Base.Galaxy;
using OnlineStrategyGame.Base.Galaxy.Interfaces;
using OnlineStrategyGame.Database.MSSQL;
using OnlineStrategyGame.Database.MSSQL.Models;
using OnlineStrategyGame.Dtos.Galaxy;

namespace OnlineStrategyGame.WebApp.Controllers
{
    public class SolarSystemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISolarSystemManager _solarSystemManager;

        public SolarSystemsController(ApplicationDbContext context, ISolarSystemManager solarSystemManager)
        {
            _context = context;
            _solarSystemManager = solarSystemManager;
        }

        // GET: SolarSystems
        public async Task<IActionResult> Index()
        {
            return View(new List<SolarSystemDto>() { _solarSystemManager.GetSolarSystem(1, 1, 1) });
        }

        // GET: SolarSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solarSystem = await _context.SolarSystems
                .Include(s => s.Ruler)
                .Include(s => s.Star)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solarSystem == null)
            {
                return NotFound();
            }

            return View(solarSystem);
        }

        // GET: SolarSystems/Create
        public IActionResult Create()
        {
            ViewData["RulerId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["StarId"] = new SelectList(_context.Stars, "Id", "Id");
            return View();
        }

        // POST: SolarSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RulerId,StarId,CordX,CordY,CordZ")] SolarSystem solarSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solarSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RulerId"] = new SelectList(_context.Users, "Id", "Id", solarSystem.RulerId);
            ViewData["StarId"] = new SelectList(_context.Stars, "Id", "Id", solarSystem.StarId);
            return View(solarSystem);
        }

        // GET: SolarSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solarSystem = await _context.SolarSystems.FindAsync(id);
            if (solarSystem == null)
            {
                return NotFound();
            }
            ViewData["RulerId"] = new SelectList(_context.Users, "Id", "Id", solarSystem.RulerId);
            ViewData["StarId"] = new SelectList(_context.Stars, "Id", "Id", solarSystem.StarId);
            return View(solarSystem);
        }

        // POST: SolarSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RulerId,StarId,CordX,CordY,CordZ")] SolarSystem solarSystem)
        {
            if (id != solarSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solarSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolarSystemExists(solarSystem.Id))
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
            ViewData["RulerId"] = new SelectList(_context.Users, "Id", "Id", solarSystem.RulerId);
            ViewData["StarId"] = new SelectList(_context.Stars, "Id", "Id", solarSystem.StarId);
            return View(solarSystem);
        }

        // GET: SolarSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solarSystem = await _context.SolarSystems
                .Include(s => s.Ruler)
                .Include(s => s.Star)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solarSystem == null)
            {
                return NotFound();
            }

            return View(solarSystem);
        }

        // POST: SolarSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solarSystem = await _context.SolarSystems.FindAsync(id);
            _context.SolarSystems.Remove(solarSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolarSystemExists(int id)
        {
            return _context.SolarSystems.Any(e => e.Id == id);
        }
    }
}
