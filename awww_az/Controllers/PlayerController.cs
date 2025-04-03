using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using awww_az.Data;
using awww_az.Models;
using System.Linq;
using System.Threading.Tasks;

namespace awww_az.Controllers
{
    public class PlayerController : Controller
    {
        private readonly AppDbContext _context;

        public PlayerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Player
        public async Task<IActionResult> Index()
        {
            var players = await _context.Players
                .Include(p => p.Team)
                .Include(p => p.Position)
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToListAsync();
            return View(players);
        }

        // GET: Player/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Team)
                .Include(p => p.Position)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Player/Create
        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name");
            return View();
        }

        // POST: Player/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Country,BirthDate,TeamId,PositionId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Player created successfully!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", player.PositionId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Player/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", player.PositionId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", player.TeamId);

            // Add audit information
            ViewData["CurrentDate"] = "2025-04-02 07:30:28";
            ViewData["CurrentUser"] = "GoldsteinAZ";

            return View(player);
        }

        // POST: Player/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Country,BirthDate,TeamId,PositionId")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Player updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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

            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", player.PositionId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", player.TeamId);

            // Add audit information
            ViewData["CurrentDate"] = "2025-04-02 07:30:28";
            ViewData["CurrentUser"] = "GoldsteinAZ";

            return View(player);
        }

        // GET: Player/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Team)
                .Include(p => p.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Players.FindAsync(id);

            // Check if player has match players
            var hasMatchPlayers = await _context.MatchPlayers.AnyAsync(mp => mp.PlayerId == id);
            if (hasMatchPlayers)
            {
                TempData["ErrorMessage"] = "Cannot delete player because they have match records associated with them.";
                return RedirectToAction(nameof(Index));
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Player deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}