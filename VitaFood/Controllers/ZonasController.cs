using Microsoft.AspNetCore.Mvc;
using VitaFood.Models;

namespace VitaFood.Controllers
{
    public class ZonasController : Controller
    {
        private readonly VitaFoodContext _context;

        public ZonasController(VitaFoodContext context)
        {
            _context = context;
        }

        // GET: Zonas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zonas.ToListAsync());
        }

        // GET: Zonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var zona = await _context.Zonas.FirstOrDefaultAsync(m => m.ZonaId == id);
            if (zona == null) return NotFound();

            return View(zona);
        }

        // GET: Zonas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zonas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZonaId,Nombre,Descripcion")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zona);
        }

        // GET: Zonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var zona = await _context.Zonas.FindAsync(id);
            if (zona == null) return NotFound();

            return View(zona);
        }

        // POST: Zonas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZonaId,Nombre,Descripcion")] Zona zona)
        {
            if (id != zona.ZonaId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(zona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zona);
        }

        // GET: Zonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var zona = await _context.Zonas.FirstOrDefaultAsync(m => m.ZonaId == id);
            if (zona == null) return NotFound();

            return View(zona);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zona = await _context.Zonas.FindAsync(id);
            _context.Zonas.Remove(zona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
