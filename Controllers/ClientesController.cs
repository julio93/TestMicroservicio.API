using Microsoft.AspNetCore.Mvc;
using TestMicroservicio.Models;
using System.Linq;


namespace TestMicroservicio.API.Controllers
{
    [Route("clientes/")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly ApplicationDbContext _context;
        public ClientesController(ILogger<ClientesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<List<Cliente>>> GetClientes()
        {
            return Ok(await _context.Clientes.ToListAsync());
        }

        [HttpGet("get")]
        public ActionResult<Cliente> GetCliente(int idCliente = 0)
        {
            var cliente = _context.Clientes.FindAsync(idCliente);

            if (cliente == null)
                return BadRequest("Cliente no existe..");
            else 
                return Ok(cliente);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Cliente cliente)
        {
            try 
            {
                _context.Clientes.Add(cliente);

                await _context.SaveChangesAsync();

                return Ok("Cliente guardado exitosamente..");
            }
            catch (Exception ex) 
            {
                return BadRequest("Ocurrio un error al Insertar Cliente: " + ex.Message);
            }
            
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);

                await _context.SaveChangesAsync();

                return Ok("Cliente actualizado exitosamente..");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error al actualizar Cliente: " + ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Cliente cliente)
        {
            try
            {
                _context.Clientes.Remove(cliente);

                await _context.SaveChangesAsync();

                return Ok("Cliente eliminado exitosamente..");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error al eliminar Cliente: " + ex.Message);
            }
        }
    }
}