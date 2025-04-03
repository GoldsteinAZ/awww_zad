using Microsoft.AspNetCore.Mvc;
using awww_az.Data;
using awww_az.Models;
using System.Threading.Tasks;

namespace awww_az.Controllers
{
    public class LeagueController : Controller
    {
        private readonly AppDbContext _context;

        public LeagueController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(League league)
        {
            if (ModelState.IsValid)
            {
                _context.Leagues.Add(league);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(league);
        }
    }
}

