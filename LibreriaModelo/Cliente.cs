using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaModelo
{
    public class Cliente
    {
        [Key] public int Id { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Correo_Cliente { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contrasena_Cliente { get; set; }

        List<Prestamo>? Prestamos { get; set; } = new List<Prestamo>(); //Una buena práctica es inicializarla de una vez
    }
}
