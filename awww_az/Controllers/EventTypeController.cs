using Microsoft.AspNetCore.Mvc;
using awww_az.Data;
using awww_az.Models;
using System.Threading.Tasks;

namespace awww_az.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly AppDbContext _context;

        public EventTypeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventType eventType)
        {
            if (ModelState.IsValid)
            {
                _context.EventTypes.Add(eventType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(eventType);
        }
    }
}

