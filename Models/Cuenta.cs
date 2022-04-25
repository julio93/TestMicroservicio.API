using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMicroservicio.Models
{
    public class Cuenta
    {
        [Key]
        public int IDCuenta { get; set; }
        public int NumeroCuenta { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Tipo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int IDCliente { get; set; }

        public static implicit operator Cuenta(ActionResult<Cuenta> v)
        {
            throw new NotImplementedException();
        }
    }
}
