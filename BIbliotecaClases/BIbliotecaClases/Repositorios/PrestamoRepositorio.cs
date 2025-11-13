
using BIbliotecaClases.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases.Repositorios
{
    public class PrestamoRepositorio : RepositorioBase<Prestamo>
    {
        public PrestamoRepositorio(ApplicationDbContext context) : base(context) {}

        public List<Prestamo> ObtenerPrestamosPorSocio(int socioId)
        {
            return _context.Prestamos
                .Include(p => p.Libro)
                .Where(p => p.SocioId == socioId)
                .ToList();
        }
    }
}
