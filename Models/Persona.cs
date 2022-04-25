using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMicroservicio.Models
{
    public class Persona
    {
        [Column(TypeName = "varchar(25)")]
        public string Identificacion { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string Genero { get; set; }
        public int Edad { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Direccion { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string Telefono { get; set; }


    }
}
