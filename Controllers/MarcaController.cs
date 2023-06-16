using AprendiendoAsp.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoAsp.Net.Controllers
{
    public class MarcaController : Controller
    {
        private readonly EjercicioAspNetContext _context;

        public MarcaController(EjercicioAspNetContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Marcas.ToListAsync();
            return View(model);
        }
    }
}
