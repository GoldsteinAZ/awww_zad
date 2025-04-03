using Microsoft.AspNetCore.Mvc;
using awww_az.Data;
using awww_az.Models;
using System.Threading.Tasks;

namespace awww_az.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(category);
        }
    }
}
