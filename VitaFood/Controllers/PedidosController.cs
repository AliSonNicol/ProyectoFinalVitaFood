using Microsoft.AspNetCore.Mvc;
using VitaFood.Models;

namespace VitaFood.Controllers
{
    public class PedidosController : Controller
    {
        private readonly VitaFoodContext _context;

        public PedidosController(VitaFoodContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var pedidos = _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Zona);
            return View(await pedidos.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Zona)
                .Include(p => p.Detalles)
                .ThenInclude(d => d.MenuDia)
                .FirstOrDefaultAsync(m => m.PedidoId == id);

            if (pedido == null) return NotFound();

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Cliente, "ClienteId", "Nombre");
            ViewData["ZonaId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Zona, "ZonaId", "Nombre");
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,Fecha,Estado,ClienteId,ZonaId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null) return NotFound();

            ViewData["ClienteId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Cliente, "ClienteId", "Nombre", pedido.ClienteId);
            ViewData["ZonaId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Zona, "ZonaId", "Nombre", pedido.ZonaId);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,Fecha,Estado,ClienteId,ZonaId")] Pedido pedido)
        {
            if (id != pedido.PedidoId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Pedido.Any(e => e.PedidoId == pedido.PedidoId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Zona)
                .FirstOrDefaultAsync(m => m.PedidoId == id);

            if (pedido == null) return NotFound();

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
