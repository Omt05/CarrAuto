using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarrAuto.Models;
using CarrAuto.Data;
using Microsoft.EntityFrameworkCore;

namespace CarrAuto.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Récupérer les derniers véhicules ajoutés pour l'affichage sur la page d'accueil
        var derniersVehicules = await _context.VehiculesOccasion
            .Where(v => v.EstDisponible)
            .OrderByDescending(v => v.DateMiseEnVente)
            .Take(3)
            .ToListAsync();

        // Récupérer quelques services pour l'affichage sur la page d'accueil
        var services = await _context.Services
            .Include(s => s.CategorieService)
            .Take(4)
            .ToListAsync();

        // Passer les données à la vue
        ViewBag.DerniersVehicules = derniersVehicules;
        ViewBag.Services = services;

        return View();
    }

    public IActionResult Histoire()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Contact(string nom, string email, string message)
    {
        // Dans une application réelle, nous enverrions ici un email ou enregistrerions
        // le message dans la base de données
        ViewBag.MessageEnvoye = true;
        return View();
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
