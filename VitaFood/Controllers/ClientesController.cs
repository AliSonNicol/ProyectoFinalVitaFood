using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VitaFood.Models;

namespace VitaFood.Controllers
{
    public class ClientesController : Controller
    {
        private readonly VitaFoodContext _context;

        public ClientesController(VitaFoodContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = _context.Clientes.Include(c => c.Zona);
            return View(await clientes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes
                .Include(c => c.Zona)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        public IActionResult Create()
        {
            ViewData["ZonaId"] = new SelectList(_context.Zonas, "ZonaId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nombre,Usuario,Contrasena,Rol,ZonaId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ZonaId"] = new SelectList(_context.Zonas, "ZonaId", "Nombre", cliente.ZonaId);
            return View(cliente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            ViewData["ZonaId"] = new SelectList(_context.Zonas, "ZonaId", "Nombre", cliente.ZonaId);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nombre,Usuario,Contrasena,Rol,ZonaId")] Cliente cliente)
        {
            if (id != cliente.ClienteId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ZonaId"] = new SelectList(_context.Zonas, "ZonaId", "Nombre", cliente.ZonaId);
            return View(cliente);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes
                .Include(c => c.Zona)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
