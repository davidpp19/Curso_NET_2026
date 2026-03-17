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
        public string nombreBiblioteca { get; set; }
        public string direccion { get; set; }

    }
}
