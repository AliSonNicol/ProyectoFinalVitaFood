using Microsoft.AspNetCore.Mvc;
using VitaFood.Models;

namespace VitaFood.Controllers
{
    public class MenuDiaController : Controller
    {
        private readonly VitaFoodContext _context;

        public MenuDiaController(VitaFoodContext context)
        {
            _context = context;
        }

        // GET: MenuDia
        public async Task<IActionResult> Index()
        {
            return View(await _context.MenuDia.ToListAsync());
        }

        // GET: MenuDia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var menu = await _context.MenuDia.FirstOrDefaultAsync(m => m.MenuDiaId == id);
            if (menu == null) return NotFound();

            return View(menu);
        }

        // GET: MenuDia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuDia/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuDiaId,Nombre,Descripcion,Precio")] MenuDia menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: MenuDia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var menu = await _context.MenuDia.FindAsync(id);
            if (menu == null) return NotFound();

            return View(menu);
        }

        // POST: MenuDia/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuDiaId,Nombre,Descripcion,Precio")] MenuDia menu)
        {
            if (id != menu.MenuDiaId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.MenuDia.Any(e => e.MenuDiaId == menu.MenuDiaId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: MenuDia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var menu = await _context.MenuDia.FirstOrDefaultAsync(m => m.MenuDiaId == id);
            if (menu == null) return NotFound();

            return View(menu);
        }

        // POST: MenuDia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.MenuDia.FindAsync(id);
            _context.MenuDia.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
