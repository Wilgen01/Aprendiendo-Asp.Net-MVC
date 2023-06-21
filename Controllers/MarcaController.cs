using AprendiendoAsp.Net.Models;
using AprendiendoAsp.Net.Models.ViewModels;
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

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(MarcaViewModel marca)
        {
            if (!ModelState.IsValid)
            {
                return View(marca);
            }

            var existeMarca = await _context.Marcas.AnyAsync(m => m.Nombre == marca.Nombre);

            if (existeMarca)
            {   
                ModelState.AddModelError(nameof(marca.Nombre), $"La marca {marca.Nombre} ya se encuentra registrada");
                return View(marca);
            }


            var model = new Marca()
            {
                Nombre = marca.Nombre,
                Descripcion = marca.Descripcion,
            };

            _context.Marcas.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
