using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryDbContext _context;

        public HomeController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totalLibros = _context.Libros.Count();

            var prestadosHoy = _context.Prestamos.Count(p =>
                p.FechaPrestamo.Date == DateTime.Today);

            var atrasados = _context.Prestamos.Count(p =>
            p.FechaDevolucion <= DateTime.Today);

            var prestamos = _context.Prestamos
            .Include(p => p.Libro)
            .OrderByDescending(p => p.FechaPrestamo)
            .ToList();

            var model = new DashboardViewModel
            {
                TotalLibros = totalLibros,
                PrestadosHoy = prestadosHoy,
                Atrasados = atrasados,
                Prestamos = prestamos
            };

            return View(model);
        }

    }
}