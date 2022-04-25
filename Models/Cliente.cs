using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMicroservicio.Models
{
    public class Cliente : Persona
    {
        [Key]
        public int IDCliente { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
    }
}
