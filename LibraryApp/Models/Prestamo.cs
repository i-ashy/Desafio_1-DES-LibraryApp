using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
    public class Prestamo
    {
        public int Id { get; set; }

        [ForeignKey("Libro")]
        public int LibroId { get; set; }

        public Libro Libro { get; set; }

        [Required(ErrorMessage = "El nombre del estudiante es obligatorio")]
        public string Estudiante { get; set; }

        public DateTime FechaPrestamo { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de devolución esperada")]
        [DataType(DataType.Date)]
        public DateTime FechaDevolucion { get; set; }
    }

}
