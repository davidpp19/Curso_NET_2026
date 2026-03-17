using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaModelo
{
    public class Autor
    {
        [Key] public int Id { get; set; }
        public string Nombres_Autor { get; set; }
        public string Apellidos_Autor { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }

        //LLave foranea
        [ForeignKey("PaisId")] //Siempre el nombre y despues el "Id"
        public int PaisId { get; set; }

        //Objeto de navegación
        public Pais? Pais { get; set; }

        List<Libro>? Libros { get; set; } = new List<Libro>(); //Una buena práctica es inicializarla de una vez
    }
}
