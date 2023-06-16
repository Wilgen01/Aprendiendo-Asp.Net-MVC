using AprendiendoAsp.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoAsp.Net.Controllers
{
    public class CelularesController : Controller
    {
        private readonly EjercicioAspNetContext _context;

        public CelularesController(EjercicioAspNetContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var celulares = _context.Celulars.Include(b => b.Marca);
            return View(await celulares.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }

    }
}
