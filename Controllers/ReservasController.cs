using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reservasjc.Data;
using reservasjc.Models;
using System.Threading.Tasks;

namespace reservasjc.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ReservaContext _context;

        public ReservasController(ReservaContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservas.ToListAsync());
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCliente,FechaReserva,NumeroPersonas,Observaciones")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }
    }
}
