using Microsoft.AspNetCore.Mvc;
using TestMicroservicio.Models;
using System.Linq;
using System.Globalization;

namespace TestMicroservicio.API.Controllers
{
    [Route("reportes/")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly ILogger<ReportesController> _logger;
        private readonly ApplicationDbContext _context;
        public ReportesController(ILogger<ReportesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<List<Reporte>>> GetReportes(string fechaInicio, string fechaFin, int idCliente)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.IDCliente == idCliente);

            var cuentas = _context.Cuentas.Where(x => x.IDCliente == idCliente).ToList();

            DateTime inicio = DateTime.Parse(fechaInicio, CultureInfo.InvariantCulture);

            DateTime fin = DateTime.Parse(fechaFin, CultureInfo.InvariantCulture).AddHours(23);

            List<Reporte> reporte =  new List<Reporte>();

            foreach (Cuenta item in cuentas) 
            {
                var movimientos = _context.Movimientos.Where(x => x.NumeroCuenta == item.NumeroCuenta && x.Fecha >= inicio && x.Fecha <= fin);

                foreach (Movimiento item2 in movimientos) 
                {
                    reporte.Add(new Reporte()
                    {
                        Fecha = item2.Fecha.ToShortDateString(),
                        NombreCliente = cliente.Nombre,
                        NumeroCuenta = item.NumeroCuenta,
                        Tipo = item.Tipo,
                        SaldoInicial = item.SaldoInicial,
                        Estado = item.Estado,
                        Cantidad = item2.Valor,
                        SaldoDisponible = item2.Saldo
                    });
                }
            }

            return Ok(reporte);
        }
    }
}