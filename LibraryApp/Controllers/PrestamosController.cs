using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly LibraryDbContext _context;

        public PrestamosController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            ViewBag.Libros = new SelectList(_context.Libros.Where(l => l.Disponible), "Id", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                var libro = _context.Libros.Find(prestamo.LibroId);
                if (libro == null || !libro.Disponible)
                {
                    ModelState.AddModelError("LibroId", "El libro no está disponible.");
                }
                else
                {
                    libro.Disponible = false;
                    prestamo.FechaPrestamo = DateTime.Now;
                    prestamo.FechaDevolucion = prestamo.FechaDevolucion.Date;
                    _context.Prestamos.Add(prestamo);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Libros");
                }
            }

            ViewBag.Libros = new SelectList(_context.Libros.Where(l => l.Disponible), "Id", "Titulo", prestamo.LibroId);
            return View(prestamo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Devolver(int id)
        {
            var prestamo = _context.Prestamos.Include(p => p.Libro).FirstOrDefault(p => p.Id == id);
            if (prestamo != null)
            {
                prestamo.Libro.Disponible = true;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

