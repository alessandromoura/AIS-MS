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
    public class GamesController : Controller
    {
        private readonly TicketsDbContext _context;

        public GamesController(TicketsDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var ticketsDbContext = _context.Games.Include(g => g.Championship).Include(g => g.Stadium).Include(g => g.TeamAway).Include(g => g.TeamHome);
            return View(await ticketsDbContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameEntity = await _context.Games
                .Include(g => g.Championship)
                .Include(g => g.Stadium)
                .Include(g => g.TeamAway)
                .Include(g => g.TeamHome)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameEntity == null)
            {
                return NotFound();
            }

            return View(gameEntity);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["ChampionshipId"] = new SelectList(_context.Championships, "Id", "Id");
            ViewData["StadiumId"] = new SelectList(_context.Stadiums, "Id", "Id");
            ViewData["TeamAwayId"] = new SelectList(_context.Teams, "Id", "Id");
            ViewData["TeamHomeId"] = new SelectList(_context.Teams, "Id", "Id");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamHomeId,TeamAwayId,StadiumId,ChampionshipId")] GameEntity gameEntity)
        {
            if (ModelState.IsValid)
            {
                gameEntity.Id = Guid.NewGuid();
                _context.Add(gameEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChampionshipId"] = new SelectList(_context.Championships, "Id", "Id", gameEntity.ChampionshipId);
            ViewData["StadiumId"] = new SelectList(_context.Stadiums, "Id", "Id", gameEntity.StadiumId);
            ViewData["TeamAwayId"] = new SelectList(_context.Teams, "Id", "Id", gameEntity.TeamAwayId);
            ViewData["TeamHomeId"] = new SelectList(_context.Teams, "Id", "Id", gameEntity.TeamHomeId);
            return View(gameEntity);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameEntity = await _context.Games.FindAsync(id);
            if (gameEntity == null)
            {
                return NotFound();
            }
            ViewData["ChampionshipId"] = new SelectList(_context.Championships, "Id", "Id", gameEntity.ChampionshipId);
            ViewData["StadiumId"] = new SelectList(_context.Stadiums, "Id", "Id", gameEntity.StadiumId);
            ViewData["TeamAwayId"] = new SelectList(_context.Teams, "Id", "Id", gameEntity.TeamAwayId);
            ViewData["TeamHomeId"] = new SelectList(_context.Teams, "Id", "Id", gameEntity.TeamHomeId);
            return View(gameEntity);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TeamHomeId,TeamAwayId,StadiumId,ChampionshipId")] GameEntity gameEntity)
        {
            if (id != gameEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameEntityExists(gameEntity.Id))
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
            ViewData["ChampionshipId"] = new SelectList(_context.Championships, "Id", "Id", gameEntity.ChampionshipId);
            ViewData["StadiumId"] = new SelectList(_context.Stadiums, "Id", "Id", gameEntity.StadiumId);
            ViewData["TeamAwayId"] = new SelectList(_context.Teams, "Id", "Id", gameEntity.TeamAwayId);
            ViewData["TeamHomeId"] = new SelectList(_context.Teams, "Id", "Id", gameEntity.TeamHomeId);
            return View(gameEntity);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameEntity = await _context.Games
                .Include(g => g.Championship)
                .Include(g => g.Stadium)
                .Include(g => g.TeamAway)
                .Include(g => g.TeamHome)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameEntity == null)
            {
                return NotFound();
            }

            return View(gameEntity);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var gameEntity = await _context.Games.FindAsync(id);
            _context.Games.Remove(gameEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameEntityExists(Guid id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
