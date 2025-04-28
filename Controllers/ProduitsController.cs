using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarrAuto.Data;
using CarrAuto.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CarrAuto.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProduitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produits
        public async Task<IActionResult> Index()
        {
            var produits = await _context.Produits
                .Include(p => p.CategorieProduit)
                .ToListAsync();
            return View(produits);
        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !ModelState.IsValid)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .Include(p => p.CategorieProduit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // GET: Produits/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.CategoriesProduits.ToListAsync();
            return View();
        }

        // POST: Produits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description,Prix,PrixPromotion,EnPromotion,EstPopulaire,EnStock,QuantiteStock,ImageUrl,CategorieProduitId,EstDisponible")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = await _context.CategoriesProduits.ToListAsync();
            return View(produit);
        }

        // GET: Produits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !ModelState.IsValid)
            {
                return NotFound();
            }

            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.CategoriesProduits.ToListAsync();
            return View(produit);
        }

        // POST: Produits/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Description,Prix,PrixPromotion,EnPromotion,EstPopulaire,EnStock,QuantiteStock,ImageUrl,CategorieProduitId,EstDisponible")] Produit produit)
        {
            if (id != produit.Id || !ModelState.IsValid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProduitExists(produit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
            
            ViewBag.Categories = await _context.CategoriesProduits.ToListAsync();
            return View(produit);
        }

        // GET: Produits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !ModelState.IsValid)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .Include(p => p.CategorieProduit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            
            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProduitExists(int id)
        {
            return await _context.Produits.AnyAsync(e => e.Id == id);
        }

        // GET: Produits/ParCategorie/5
        public async Task<IActionResult> ParCategorie(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var categorie = await _context.CategoriesProduits.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            var produits = await _context.Produits
                .Where(p => p.CategorieProduitId == id)
                .ToListAsync();

            ViewBag.CategorieActuelle = categorie;
            ViewBag.Categories = await _context.CategoriesProduits.ToListAsync();

            return View("Index", produits);
        }
    }
}
