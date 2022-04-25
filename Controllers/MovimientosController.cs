using Microsoft.AspNetCore.Mvc;
using TestMicroservicio.Models;
using System.Linq;
using TestMicroservicio.API.Util;
using System.Collections.Generic;

namespace TestMicroservicio.API.Controllers
{
    [Route("movimientos/")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly CuentasController _cuentasController;

        public MovimientosController(ApplicationDbContext context)
        {
            _context = context;
            _cuentasController = new CuentasController(context);
        }

        [HttpGet("getlist")]
        public ActionResult<List<Movimiento>> GetMovimientos()
        {
            return Ok(_context.Movimientos.ToListAsync());
        }

        [HttpGet("get")]
        public async Task<ActionResult<Movimiento>> GetMovimiento(int idMovimiento = 0)
        {
            var Movimiento = await _context.Movimientos.FindAsync(idMovimiento);

            if (Movimiento == null)
                return BadRequest("Movimiento no existe..");
            else
                return Ok(Movimiento);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Movimiento movimiento)
        {
            try
            {
                var cuenta = (Cuenta)_context.Cuentas.FirstOrDefault(x => x.NumeroCuenta == movimiento.NumeroCuenta);

                IEnumerable<Movimiento> movimientos = _context.Movimientos.ToList().Where(x => x.NumeroCuenta == 
                                                    movimiento.NumeroCuenta && x.TipoMovimiento == "Retiro");

                decimal montoTotalRetiro = 0;

                foreach(Movimiento item in movimientos) 
                {
                    montoTotalRetiro += item.Valor * -1;
                }

                if (cuenta == null || !cuenta.Estado)
                    return BadRequest("Cuenta no existe o esta inactiva.");
                else 
                {
                    if (movimiento.TipoMovimiento == "Retiro") 
                    {
                        if (cuenta.SaldoInicial < movimiento.Valor)
                            return BadRequest("Saldo no disponible.");
                        else if (montoTotalRetiro + movimiento.Valor > 1000)
                            return BadRequest("Cupo diario Excedido.");
                        else 
                        {
                            movimiento.Saldo = cuenta.SaldoInicial - movimiento.Valor;

                            cuenta.SaldoInicial -= movimiento.Valor;    

                            movimiento.Valor = movimiento.Valor * -1;
                        }
                                            
                    }
                    else
                    {
                        movimiento.Saldo = cuenta.SaldoInicial + movimiento.Valor;

                        cuenta.SaldoInicial += movimiento.Valor;
                    }
                }

                _context.Cuentas.Update(cuenta);
                _context.Movimientos.Add(movimiento);

                await _context.SaveChangesAsync();

                return Ok("Movimiento guardada exitosamente..");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error al Insertar Movimiento: " + ex.Message);
            }

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Movimiento Movimiento)
        {
            try
            {
                _context.Movimientos.Update(Movimiento);

                await _context.SaveChangesAsync();

                return Ok("Movimiento actualizada exitosamente..");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error al actualizar Movimiento: " + ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Movimiento Movimiento)
        {
            try
            {
                _context.Movimientos.Remove(Movimiento);

                await _context.SaveChangesAsync();

                return Ok("Movimiento eliminada exitosamente..");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error al eliminar Movimiento: " + ex.Message);
            }
        }
    }
}