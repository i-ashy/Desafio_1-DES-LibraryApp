using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Autor { get; set; }
        public bool Disponible { get; set; }
    }

}
