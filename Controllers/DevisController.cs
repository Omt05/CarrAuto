using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarrAuto.Data;
using CarrAuto.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CarrAuto.Controllers
{
    public class DevisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Devis
        public async Task<IActionResult> Index()
        {
            return View(await _context.DemandesDevis.ToListAsync());
        }

        // GET: Devis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeDevis = await _context.DemandesDevis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demandeDevis == null)
            {
                return NotFound();
            }

            return View(demandeDevis);
        }

        // GET: Devis/Create
        public async Task<IActionResult> Create()
        {
            // Récupérer les services pour les afficher dans le formulaire
            ViewBag.Services = await _context.Services.Include(s => s.CategorieService).ToListAsync();
            return View();
        }

        // POST: Devis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Prenom,Email,Telephone,MarqueVehicule,ModeleVehicule,AnneeVehicule,DescriptionTravaux")] DemandeDevis demandeDevis)
        {
            if (ModelState.IsValid)
            {
                demandeDevis.DateDemande = DateTime.UtcNow;
                demandeDevis.Statut = "En attente";
                _context.Add(demandeDevis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Confirmation), new { id = demandeDevis.Id });
            }
            ViewBag.Services = _context.Services.Include(s => s.CategorieService).ToList();
            return View(demandeDevis);
        }

        // GET: Devis/Confirmation/5
        public async Task<IActionResult> Confirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeDevis = await _context.DemandesDevis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demandeDevis == null)
            {
                return NotFound();
            }

            return View(demandeDevis);
        }

        // GET: Devis/Edit/5 (Admin only)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeDevis = await _context.DemandesDevis.FindAsync(id);
            if (demandeDevis == null)
            {
                return NotFound();
            }
            return View(demandeDevis);
        }

        // POST: Devis/Edit/5 (Admin only)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,Telephone,MarqueVehicule,ModeleVehicule,AnneeVehicule,DescriptionTravaux,DateDemande,Statut,MontantDevis,CommentairesInternes")] DemandeDevis demandeDevis)
        {
            if (id != demandeDevis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demandeDevis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandeDevisExists(demandeDevis.Id))
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
            return View(demandeDevis);
        }

        // GET: Devis/Delete/5 (Admin only)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeDevis = await _context.DemandesDevis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demandeDevis == null)
            {
                return NotFound();
            }

            return View(demandeDevis);
        }

        // POST: Devis/Delete/5 (Admin only)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demandeDevis = await _context.DemandesDevis.FindAsync(id);
            if (demandeDevis != null)
            {
                _context.DemandesDevis.Remove(demandeDevis);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        // POST: Devis/TraiterDevis/5 (Admin only)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TraiterDevis(int id, string statut, decimal? montantDevis, string commentaires)
        {
            var demandeDevis = await _context.DemandesDevis.FindAsync(id);
            if (demandeDevis == null)
            {
                return NotFound();
            }

            demandeDevis.Statut = statut;
            demandeDevis.MontantDevis = montantDevis;
            demandeDevis.CommentairesInternes = commentaires;

            _context.Update(demandeDevis);
            await _context.SaveChangesAsync();

            // Si le statut est "Accepté", on pourrait envoyer un email au client (implémentation future)

            return RedirectToAction(nameof(Index));
        }

        private bool DemandeDevisExists(int id)
        {
            return _context.DemandesDevis.Any(e => e.Id == id);
        }
    }
}
