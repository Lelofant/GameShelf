using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameShelf.Data;
using GameShelf.Models;

namespace GameShelf.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlatformsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            List<Platform> platforms = 
                _context.Platforms
                .Include(p => p.Games)
                .ToList();

            return View(platforms);
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Platform platform = _context.Platforms.Find(id);

            if (platform == null)
            {
                return NotFound();
            }

            return View(platform);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Platform platform)
        {
            if (ModelState.IsValid)
            {
                _context.Platforms.Add(platform);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(platform);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Platform platform = _context.Platforms.Find(id);

            if (platform == null)
            {
                return NotFound();
            }

            return View(platform);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id ,Platform platform)
        {
            if(id != platform.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Platforms.Update(platform);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(platform);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Platform platform = _context.Platforms.Find(id);
            if (platform == null)
            {
                return NotFound();
            }
            return View(platform);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Platform platform = _context.Platforms.Find(id);

            if (platform != null)
            {
                _context.Platforms.Remove(platform);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
