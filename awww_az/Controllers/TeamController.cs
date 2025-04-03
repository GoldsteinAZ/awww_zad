using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using awww_az.Data;
using awww_az.Models;
using System.Linq;
using System.Threading.Tasks;

namespace awww_az.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Team
        public async Task<IActionResult> Index()
        {
            var teams = await _context.Teams
                .Include(t => t.League)
                .OrderBy(t => t.Name)
                .ToListAsync();
            return View(teams);
        }

        // GET: Team/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.League)
                .Include(t => t.Players)
                .ThenInclude(p => p.Position)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "Id", "Name");
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,City,FoundingDate,LeagueId")] Team team)
        {
            // Dodaj debugowanie
            ModelState.Remove("League"); // Usuwamy League z walidacji, bo to relacja
            ModelState.Remove("Players"); // Usuwamy Players z walidacji, bo to relacja

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(team);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Team created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Dodaj obsługę błędów
                    ModelState.AddModelError("", "Wystąpił błąd podczas zapisywania: " + ex.Message);
                }
            }

            // Jeśli dotarliśmy tutaj, coś poszło nie tak
            // Dodaj debugging informacji o błędach walidacji
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    TempData["ErrorInfo"] = $"Field: {state.Key}, Errors: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}";
                }
            }

            ViewData["LeagueId"] = new SelectList(_context.Leagues, "Id", "Name", team.LeagueId);
            return View(team);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "Id", "Name", team.LeagueId);
            
            // Add audit information
            ViewData["CurrentDate"] = "2025-04-02 07:30:28";
            ViewData["CurrentUser"] = "GoldsteinAZ";
            
            return View(team);
        }

        // POST: Team/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,FoundingDate,LeagueId")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            // Dodaj debugowanie
            ModelState.Remove("League"); // Usuwamy League z walidacji, bo to relacja
            ModelState.Remove("Players"); // Usuwamy Players z walidacji, bo to relacja

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Team updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        // Dodaj obsługę błędów
                        ModelState.AddModelError("", "Wystąpił błąd podczas aktualizacji. Dane mogły zostać zmienione przez innego użytkownika.");
                    }
                }
                catch (Exception ex)
                {
                    // Dodaj obsługę błędów
                    ModelState.AddModelError("", "Wystąpił błąd podczas zapisywania: " + ex.Message);
                }
            }

            // Jeśli dotarliśmy tutaj, coś poszło nie tak
            // Dodaj debugging informacji o błędach walidacji
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    TempData["ErrorInfo"] = $"Field: {state.Key}, Errors: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}";
                }
            }

            ViewData["LeagueId"] = new SelectList(_context.Leagues, "Id", "Name", team.LeagueId);

            // Add audit information
            ViewData["CurrentDate"] = "2025-04-03 18:43:47";
            ViewData["CurrentUser"] = "GoldsteinAZ";

            return View(team);
        }

        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.League)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            
            // Check if team has players
            var hasPlayers = await _context.Players.AnyAsync(p => p.TeamId == id);
            if (hasPlayers)
            {
                TempData["ErrorMessage"] = "Cannot delete team because it has players associated with it.";
                return RedirectToAction(nameof(Index));
            }
            
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Team deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}