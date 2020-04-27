﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportBook.Models;

namespace SportBook.Controllers
{
    public class LocationsController : Controller
    {
        private readonly SportbookDatabaseContext _context;

        public LocationsController(SportbookDatabaseContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var sportbookDatabaseContext = _context.Location.Include(l => l.FkCityNavigation).Include(l => l.FkGameTypeNavigation);
            return View(await sportbookDatabaseContext.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .Include(l => l.FkCityNavigation)
                .Include(l => l.FkGameTypeNavigation)
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            ViewData["FkCity"] = new SelectList(_context.City, "CityId", "CityId");
            ViewData["FkGameType"] = new SelectList(_context.GameType, "GameTypeId", "GameTypeId");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Latitude,Longitude,Address,LocationId,FkCity,FkGameType")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCity"] = new SelectList(_context.City, "CityId", "CityId", location.FkCity);
            ViewData["FkGameType"] = new SelectList(_context.GameType, "GameTypeId", "GameTypeId", location.FkGameType);
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["FkCity"] = new SelectList(_context.City, "CityId", "CityId", location.FkCity);
            ViewData["FkGameType"] = new SelectList(_context.GameType, "GameTypeId", "GameTypeId", location.FkGameType);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Latitude,Longitude,Address,LocationId,FkCity,FkGameType")] Location location)
        {
            if (id != location.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationId))
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
            ViewData["FkCity"] = new SelectList(_context.City, "CityId", "CityId", location.FkCity);
            ViewData["FkGameType"] = new SelectList(_context.GameType, "GameTypeId", "GameTypeId", location.FkGameType);
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .Include(l => l.FkCityNavigation)
                .Include(l => l.FkGameTypeNavigation)
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Location.FindAsync(id);
            _context.Location.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.LocationId == id);
        }
    }
}
