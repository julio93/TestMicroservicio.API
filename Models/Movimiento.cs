using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestMicroservicio.Models
{
    public class Movimiento
    {
        [Key]
        public int IDMovimiento { get; set; }
        public int NumeroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string TipoMovimiento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }
    }
}
