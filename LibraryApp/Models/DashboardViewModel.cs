namespace LibraryApp.Models
{
    public class DashboardViewModel
    {
        public int TotalLibros { get; set; }
        public int PrestadosHoy { get; set; }
        public int Atrasados { get; set; }

        public List<Prestamo> Prestamos { get; set; }
    }
}