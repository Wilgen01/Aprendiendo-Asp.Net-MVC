using AprendiendoAsp.Net.Models;
using AprendiendoAsp.Net.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewData["Marcas"] = new SelectList(_context.Marcas, "MarcaId", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CelularViewModel model)
        {
            if (ModelState.IsValid)
            {
                var celular = new Celular()
                {
                    Modelo = model.Modelo,
                    Precio = model.Precio,
                    MarcaId = model.MarcaId,
                };

                _context.Celulars.Add(celular);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);

        }

    }
}
