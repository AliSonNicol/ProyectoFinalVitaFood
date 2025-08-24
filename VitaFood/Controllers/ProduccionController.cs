using Microsoft.AspNetCore.Mvc;
using VitaFood.Models;

namespace VitaFood.Controllers
{
    public class ProduccionesController : Controller
    {
        public class ProduccionController : Controller
        {
            private readonly VitaFoodContext _context;

            public ProduccionController(VitaFoodContext context)
            {
                _context = context;
            }

            // GET: Produccion
            public async Task<IActionResult> Index()
            {
                var producciones = _context.Produccion
                    .Include(p => p.MenuDia);
                return View(await producciones.ToListAsync());
            }

            // GET: Produccion/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null) return NotFound();

                var produccion = await _context.Produccion
                    .Include(p => p.MenuDia)
                    .FirstOrDefaultAsync(m => m.ProduccionId == id);

                if (produccion == null) return NotFound();

                return View(produccion);
            }

            // GET: Produccion/Create
            public IActionResult Create()
            {
                ViewData["MenuDiaId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.MenuDia, "MenuDiaId", "Nombre");
                return View();
            }

            // POST: Produccion/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("ProduccionId,Fecha,CantidadTotal,MenuDiaId")] Produccion produccion)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(produccion);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(produccion);
            }

            // GET: Produccion/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null) return NotFound();

                var produccion = await _context.Produccion.FindAsync(id);
                if (produccion == null) return NotFound();

                ViewData["MenuDiaId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.MenuDia, "MenuDiaId", "Nombre", produccion.MenuDiaId);
                return View(produccion);
            }

            // POST: Produccion/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ProduccionId,Fecha,CantidadTotal,MenuDiaId")] Produccion produccion)
            {
                if (id != produccion.ProduccionId) return NotFound();

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(produccion);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!_context.Produccion.Any(e => e.ProduccionId == produccion.ProduccionId)) return NotFound();
                        else throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(produccion);
            }

            // GET: Produccion/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null) return NotFound();

                var produccion = await _context.Produccion
                    .Include(p => p.MenuDia)
                    .FirstOrDefaultAsync(m => m.ProduccionId == id);

                if (produccion == null) return NotFound();

                return View(produccion);
            }

            // POST: Produccion/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var produccion = await _context.Produccion.FindAsync(id);
                _context.Produccion.Remove(produccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }

}

