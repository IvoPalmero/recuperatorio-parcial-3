using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIbliotecaClases.Modelos
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int SocioId { get; set; }
        public Socio Socio { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
    }
}
