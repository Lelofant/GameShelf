using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GameShelf.Models;
using GameShelf.Data;

namespace GameShelf.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Game> allGames = _context.Games.ToList();

        ViewBag.TotalGames = allGames.Count;
        ViewBag.CompletedGames = allGames.Count(g => g.IsCompleted);
       

        List<Platform> allPlatforms = _context.Platforms.ToList();
        ViewBag.Platforms = allPlatforms.Count;

        List<Genre> allGenres = _context.Genres.ToList();
        ViewBag.Genres = allGenres.Count;

        foreach (var game in allGames)
        {
            game.Platform = allPlatforms.FirstOrDefault(p => p.Id == game.PlatformId);
            game.Genre = allGenres.FirstOrDefault(g => g.Id == game.GenreId);
        }

        List<Game> recentGames = allGames.OrderByDescending(g => g.Id).Take(5).ToList();

        return View(allGames);

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
