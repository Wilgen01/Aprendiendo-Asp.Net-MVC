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
            
            return View(await _context.Celulars.Include(b => b.Marca).ToListAsync());
        }
    }
}
