using Microsoft.AspNetCore.Mvc;
using TestMicroservicio.Models;
using System.Linq;


namespace TestMicroservicio.API.Controllers
{
    [Route("cuentas/")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CuentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getlist")]
        public ActionResult<List<Cuenta>> GetCuentas()
        {
            return Ok(_context.Cuentas.ToListAsync());
        }

        [HttpGet("get")]
        public ActionResult<Cuenta> GetCuenta(int idCuenta = 0)
        {
            var Cuenta = _context.Cuentas.FindAsync(idCuenta);

            if (Cuenta == null)
                return BadRequest("Cuenta no existe..");
            else
                return Ok(Cuenta);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Cuenta Cuenta)
        {
            try
            {
                _context.Cuentas.Add(Cuenta);

                await _context.SaveChangesAsync();

                return Ok("Cuenta guardada exitosamente..");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error al Insertar Cuenta: " + ex.Message);
            }

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Cuenta Cuenta)
        {
            try
            {
                _context.Cuentas.Update(Cuenta);

                await _context.SaveChangesAsync();

                return Ok("Cuenta actualizada exitosamente..");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error al actualizar Cuenta: " + ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Cuenta Cuenta)
        {
            try
            {
                _context.Cuentas.Remove(Cuenta);

                await _context.SaveChangesAsync();

                return Ok("Cuenta eliminada exitosamente..");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error al eliminar Cuenta: " + ex.Message);
            }
        }
    }
}