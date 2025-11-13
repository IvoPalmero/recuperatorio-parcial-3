using BIbliotecaClases.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases.Repositorios
{
    public class SocioRepositorio : RepositorioBase<Socio>
    {
        public SocioRepositorio(ApplicationDbContext context) : base(context) {}

        public Socio? ObtenerPorId(int id)
        {
            return _context.Socios.FirstOrDefault(s => s.Id == id);
        }
    }
} 

