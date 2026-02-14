using GameShelf.Data;
using GameShelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameShelf.Controllers
{
    public class GamesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Game> games = _context.Games.ToList();
            foreach (var game in games)
            {
                game.Platform = _context.Platforms.Find(game.PlatformId);
                game.Genre = _context.Genres.Find(game.GenreId);
            }

            return View(games);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game game = _context.Games.Find(id);

            if (game == null)
            {
                return NotFound();
            }

            game.Platform = _context.Platforms.Find(game.PlatformId);
            game.Genre = _context.Genres.Find(game.GenreId);

            return View(game);

        }

        public IActionResult Create()
        {
            List<Platform> platforms = _context.Platforms.ToList();
            ViewBag.PlatformsId = new SelectList(platforms, "Id", "Name");

            List<Genre> genres = _context.Genres.ToList();
            ViewBag.GenresId = new SelectList(genres, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Platform> platforms = _context.Platforms.ToList();
            ViewBag.PlatformsId = new SelectList(platforms, "Id", "Name", game.PlatformId);

            List<Genre> genres = _context.Genres.ToList();
            ViewBag.GenresId = new SelectList(genres, "Id", "Name", game.GenreId);

            return View(game);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game game = _context.Games.Find(id);

            if (game == null)
            {
                return NotFound();
            }

            List<Platform> platforms = _context.Platforms.ToList();
            ViewBag.PlatformsId = new SelectList(platforms, "Id", "Name", game.PlatformId);

            List<Genre> genres = _context.Genres.ToList();
            ViewBag.GenresId = new SelectList(genres, "Id", "Name", game.GenreId);

            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit(int id, Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Games.Update(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Platform> platforms = _context.Platforms.ToList();
            ViewBag.PlatformsId = new SelectList(platforms, "Id", "Name", game.PlatformId);

            List<Genre> genres = _context.Genres.ToList();
            ViewBag.GenresId = new SelectList(genres, "Id", "Name", game.GenreId);

            return View(game);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game game = _context.Games.Find(id);

            if (game == null)
            {
                return NotFound();
            }

            game.Platform = _context.Platforms.Find(game.PlatformId);
            game.Genre = _context.Genres.Find(game.GenreId);   

            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Game game = _context.Games.Find(id);

            if (game != null) 
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }

}
