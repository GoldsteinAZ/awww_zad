using Microsoft.AspNetCore.Mvc;
using awww_az.Data;
using awww_az.Models;
using System.Threading.Tasks;

namespace awww_az.Controllers
{
    public class TagController : Controller
    {
        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _context.Tags.Add(tag);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(tag);
        }
    }
}
