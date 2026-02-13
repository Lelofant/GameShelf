using GameShelf.Data;
using GameShelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShelf.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Genre> genres = _context.Genres.ToList();
            return View(genres);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre genre = _context.Genres.Find(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre genre = _context.Genres.Find(id);

            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Genres.Update(genre);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        public IActionResult Delete(int? id)  
        {
            if(id == null)
            {
                return NotFound();
            }

            Genre genre = _context.Genres.Find(id);

            if(genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Genre genre = _context.Genres.Find(id);

            if (genre != null)
            { 
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
