using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaModelo
{
    public class Pais
    {
        [Key] public int Id { get; set; }
        public string Nombre_Pais { get; set; }

        //Lista de autores que pertenecen a este pais
        List<Autor>? Autores { get; set; } = new List<Autor>(); //Una buena práctica es inicializarla de una vez

    }
}
