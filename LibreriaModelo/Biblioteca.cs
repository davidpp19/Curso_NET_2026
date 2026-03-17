using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaModelo
{
    public class Biblioteca
    {
        //Llave primaria
        [Key] public int Id { get; set; }
        public string Nombre_Biblioteca { get; set; }
        public string Direccion_Biblioteca { get; set; }
        List<Libro>? Libros { get; set; } = new List<Libro>(); //Una buena práctica es inicializarla de una vez

    }
}
