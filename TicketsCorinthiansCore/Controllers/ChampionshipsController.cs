using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketsCorinthiansCore.Entities;

namespace TicketsCorinthiansCore.Controllers
{
    public class ChampionshipsController : Controller
    {
        private readonly TicketsDbContext _context;

        public ChampionshipsController(TicketsDbContext context)
        {
            _context = context;
        }

        // GET: Championships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Championships.ToListAsync());
        }

        // GET: Championships/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championshipEntity = await _context.Championships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (championshipEntity == null)
            {
                return NotFound();
            }

            return View(championshipEntity);
        }

        // GET: Championships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Championships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Trophy,Year")] ChampionshipEntity championshipEntity)
        {
            if (ModelState.IsValid)
            {
                championshipEntity.Id = Guid.NewGuid();
                _context.Add(championshipEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(championshipEntity);
        }

        // GET: Championships/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championshipEntity = await _context.Championships.FindAsync(id);
            if (championshipEntity == null)
            {
                return NotFound();
            }
            return View(championshipEntity);
        }

        // POST: Championships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Trophy,Year")] ChampionshipEntity championshipEntity)
        {
            if (id != championshipEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(championshipEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampionshipEntityExists(championshipEntity.Id))
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
            return View(championshipEntity);
        }

        // GET: Championships/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championshipEntity = await _context.Championships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (championshipEntity == null)
            {
                return NotFound();
            }

            return View(championshipEntity);
        }

        // POST: Championships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var championshipEntity = await _context.Championships.FindAsync(id);
            _context.Championships.Remove(championshipEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChampionshipEntityExists(Guid id)
        {
            return _context.Championships.Any(e => e.Id == id);
        }
    }
}
