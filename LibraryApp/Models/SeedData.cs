using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new LibraryDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<LibraryDbContext>>());

            if (context.Libros.Any()) return;

            context.Libros.AddRange(
                new Libro { Titulo = "Cien años de soledad", Autor = "G. García Márquez", Disponible = true },
                new Libro { Titulo = "1984", Autor = "George Orwell", Disponible = true },
                new Libro { Titulo = "El principito", Autor = "Antoine de Saint-Exupéry", Disponible = true },
                new Libro { Titulo = "Don Quijote", Autor = "Miguel de Cervantes", Disponible = true },
                new Libro { Titulo = "Crónica de una muerte anunciada", Autor = "G. García Márquez", Disponible = true },
                new Libro { Titulo = "La metamorfosis", Autor = "Franz Kafka", Disponible = true },
                new Libro { Titulo = "Orgullo y prejuicio", Autor = "Jane Austen", Disponible = true },
                new Libro { Titulo = "Los juegos del hambre", Autor = "Suzanne Collins", Disponible = true },
                new Libro { Titulo = "El código Da Vinci", Autor = "Dan Brown", Disponible = true },
                new Libro { Titulo = "El hobbit", Autor = "J.R.R. Tolkien", Disponible = true }
            );

            context.SaveChanges();
        }
    }

}
