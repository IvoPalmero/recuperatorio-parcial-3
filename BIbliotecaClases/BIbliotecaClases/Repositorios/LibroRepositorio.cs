using BIbliotecaClases.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases.Repositorios
{
    public class LibroRepositorio : RepositorioBase<Libro>
    {
        public LibroRepositorio(ApplicationDbContext context) : base(context) {}

        public Libro? ObtenerPorId(int id)
        {
            return _context.Libros.FirstOrDefault(l => l.Id == id);
        }

        public void Actualizar(Libro libro)
        {
            _context.Libros.Update(libro);
            _context.SaveChanges();
        }
    }
}