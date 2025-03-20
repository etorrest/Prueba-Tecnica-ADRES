using AdquisicionesADRES.Application.DTOs;
using AdquisicionesADRES.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdquisicionesADRES.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoAdquisicionController : ControllerBase
    {
        private readonly EstadoAdquisicionService _estadoService;

        public EstadoAdquisicionController(EstadoAdquisicionService estadoService)
        {
            _estadoService = estadoService;
        }

        // GET: api/EstadoAdquisicion
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estados = await _estadoService.ObtenerEstadosAsync();
            return Ok(estados);
        }

        // GET: api/EstadoAdquisicion/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estado = await _estadoService.ObtenerEstadoPorIdAsync(id);
            if (estado == null) return NotFound();

            return Ok(estado);
        }

        // POST: api/EstadoAdquisicion
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstadoAdquisicionDto dto)
        {
            var nuevo = await _estadoService.CrearEstadoAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        // PUT: api/EstadoAdquisicion/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstadoAdquisicionDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID no coincide con el DTO.");

            var actualizado = await _estadoService.ActualizarEstadoAsync(dto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        // DELETE: api/EstadoAdquisicion/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _estadoService.EliminarEstadoAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
