using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarrAuto.Data;
using CarrAuto.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CarrAuto.Controllers
{
    public class VehiculeOccasionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculeOccasionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehiculeOccasion
        public async Task<IActionResult> Index()
        {
            var vehicules = await _context.VehiculesOccasion
                .Where(v => v.EstDisponible)
                .ToListAsync();
            return View(vehicules);
        }

        // GET: VehiculeOccasion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.VehiculesOccasion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicule == null)
            {
                return NotFound();
            }

            return View(vehicule);
        }

        // GET: VehiculeOccasion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculeOccasion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Marque,Modele,Annee,Kilometrage,Prix,Description,Couleur,TypeCarburant,Transmission,ImageUrl,EstDisponible")] VehiculeOccasion vehicule)
        {
            if (ModelState.IsValid)
            {
                vehicule.DateMiseEnVente = DateTime.UtcNow;
                _context.Add(vehicule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicule);
        }

        // GET: VehiculeOccasion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.VehiculesOccasion.FindAsync(id);
            if (vehicule == null)
            {
                return NotFound();
            }
            return View(vehicule);
        }

        // POST: VehiculeOccasion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marque,Modele,Annee,Kilometrage,Prix,Description,Couleur,TypeCarburant,Transmission,ImageUrl,EstDisponible,DateMiseEnVente")] VehiculeOccasion vehicule)
        {
            if (id != vehicule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculeExists(vehicule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicule);
        }

        // GET: VehiculeOccasion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.VehiculesOccasion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicule == null)
            {
                return NotFound();
            }

            return View(vehicule);
        }

        // POST: VehiculeOccasion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicule = await _context.VehiculesOccasion.FindAsync(id);
            if (vehicule != null)
            {
                _context.VehiculesOccasion.Remove(vehicule);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculeExists(int id)
        {
            return _context.VehiculesOccasion.Any(e => e.Id == id);
        }

        // GET: VehiculeOccasion/Recherche
        public IActionResult Recherche()
        {
            return View();
        }

        // POST: VehiculeOccasion/Recherche
        [HttpPost]
        public async Task<IActionResult> ResultatsRecherche(string marque, string modele, int? anneeMin, int? anneeMax, decimal? prixMax)
        {
            var query = _context.VehiculesOccasion.AsQueryable().Where(v => v.EstDisponible);

            if (!string.IsNullOrEmpty(marque))
            {
                query = query.Where(v => v.Marque.Contains(marque));
            }

            if (!string.IsNullOrEmpty(modele))
            {
                query = query.Where(v => v.Modele.Contains(modele));
            }

            if (anneeMin.HasValue)
            {
                query = query.Where(v => v.Annee >= anneeMin.Value);
            }

            if (anneeMax.HasValue)
            {
                query = query.Where(v => v.Annee <= anneeMax.Value);
            }

            if (prixMax.HasValue)
            {
                query = query.Where(v => v.Prix <= prixMax.Value);
            }

            var resultats = await query.ToListAsync();
            return View(resultats);
        }
    }
}
