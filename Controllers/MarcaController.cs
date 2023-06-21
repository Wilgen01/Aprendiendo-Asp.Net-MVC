using AprendiendoAsp.Net.Models;
using AprendiendoAsp.Net.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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

        public async Task<IActionResult> Editar(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca is null)
            {
                return RedirectToAction("Index");
            }

            var marcaViewModel = new MarcaViewModel()
            {
                MarcaId = marca.MarcaId,
                Nombre = marca.Nombre,
                Descripcion = marca.Descripcion,
            };

            return View(marcaViewModel);
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

        [HttpPost]
        public async Task<IActionResult> Editar(int id, MarcaViewModel marca)
        {
            if (!ModelState.IsValid)
            {
                return View(marca);
            }

            var existeMarca = await _context.Marcas.AnyAsync(m => m.Nombre.Equals(marca.Nombre) && m.MarcaId != id);

            if (existeMarca)
            {
                ModelState.AddModelError(nameof(marca.Nombre), $"La marca {marca.Nombre} ya se encuentra registrada");
                return View(marca);
            }


            var editarMarca = await _context.Marcas.FindAsync(id);
            
            editarMarca.Nombre = marca.Nombre;
            editarMarca.Descripcion = marca.Descripcion;

            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var existeMarca = await _context.Marcas.AnyAsync(m => m.MarcaId.Equals(id));

            if (!existeMarca)
            {
                return RedirectToAction("Index");
            }

            var editarMarca = await _context.Marcas.FindAsync(id);
            _context.Marcas.Remove(editarMarca);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }
}
