using BibliotecaClases.Repositorios;
using BIbliotecaClases.Modelos;

var context = new ApplicationDbContext();
var repoLibros = new LibroRepositorio(context);
var repoSocios = new SocioRepositorio(context);
var repoPrestamos = new PrestamoRepositorio(context);

while (true)
{
    Console.WriteLine("1 registrar libro");
    Console.WriteLine("2 registrar socio");
    Console.WriteLine("3 registrar prestamo");
    Console.WriteLine("4 mostrar prestamos por socio");
    Console.Write("opcion:");
    var opcion = Console.ReadLine();

    if (opcion == "1")
    {
        Console.Write("titulo:");

        var titulo = Console.ReadLine();
        Console.Write("autor:");
        var autor = Console.ReadLine();
        Console.Write("cantidad disponible:");
        int.TryParse(Console.ReadLine(), out int cantidad);

        repoLibros.Agregar(new Libro { Titulo = titulo, Autor = autor, CantidadDisponible = cantidad });
        Console.WriteLine("libro registrado");
    }
    else if (opcion == "2")
    {
        Console.Write("mombre:");
        var nombre = Console.ReadLine();
        Console.Write("apellido:");
        var apellido = Console.ReadLine();
        Console.Write("dni.");
        var dni = Console.ReadLine();

        repoSocios.Agregar(new Socio { Nombre = nombre, Apellido = apellido, Dni = dni });
        Console.WriteLine("socio registrado");
    }
    else if (opcion == "2")
    {
        Console.Write("id socio:");
        int.TryParse(Console.ReadLine(), out int socioId);
        Console.Write("id libro:");
        int.TryParse(Console.ReadLine(), out int libroId);

        var socio = repoSocios.ObtenerPorId(socioId);
        var libro = repoLibros.ObtenerPorId(libroId);
        if (socio != null && libro != null && libro.CantidadDisponible > 0)
        {
            libro.CantidadDisponible--;

            repoLibros.Actualizar(libro);
            repoPrestamos.Agregar(new Prestamo { SocioId = socio.Id, LibroId = libro.Id });
            Console.WriteLine("prestamo registrado");
        }
        else
        {
            Console.WriteLine("error al registrar prestamo");
        }
    }
    else if (opcion == "4")
    {
        var socios = repoSocios.ObtenerTodos();
        foreach (var s in socios)
        {
            var prestamos = repoPrestamos.ObtenerPrestamosPorSocio(s.Id);
            Console.WriteLine($"{s.Nombre}{s.Apellido}:");
            foreach (var p in prestamos)
                Console.WriteLine($"{p.Libro.Titulo}");
        }
    }
    
}