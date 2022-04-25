using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMicroservicio.Models
{
    public class Reporte
    {

        public string Fecha { get; set; }
        public string NombreCliente { get; set; }
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial    { get; set; }
        public bool Estado  { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SaldoDisponible { get; set; }


    }
}
