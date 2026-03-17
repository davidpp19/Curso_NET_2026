using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaModelo
{
    public class Libro
    {
        [Key] public int Id { get; set; }
        public string Titulo_Libro { get; set; }
        public string Stock_Libro { get; set; }

        [ForeignKey("AutorId")]
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }

        [ForeignKey("BibliotecaId")]
        public int BibliotecaId { get; set; }
        public Biblioteca? Biblioteca { get; set; }
    }
}
