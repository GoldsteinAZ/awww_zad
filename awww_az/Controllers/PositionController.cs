using Microsoft.AspNetCore.Mvc;
using awww_az.Data;
using awww_az.Models;
using System.Threading.Tasks;

namespace awww_az.Controllers
{
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Positions.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(position);
        }
    }
}

