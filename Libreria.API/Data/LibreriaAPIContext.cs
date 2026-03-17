using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibreriaModelo;

namespace Libreria.API.Data
{
    public class LibreriaAPIContext : DbContext
    {
        public LibreriaAPIContext (DbContextOptions<LibreriaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LibreriaModelo.Autor> Autor { get; set; } = default!;
        public DbSet<LibreriaModelo.Biblioteca> Biblioteca { get; set; } = default!;
        public DbSet<LibreriaModelo.Cliente> Cliente { get; set; } = default!;
        public DbSet<LibreriaModelo.Libro> Libro { get; set; } = default!;
        public DbSet<LibreriaModelo.Pais> Pais { get; set; } = default!;
        public DbSet<LibreriaModelo.Prestamo> Prestamo { get; set; } = default!;
    }
}
