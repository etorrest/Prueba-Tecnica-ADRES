using AdquisicionesADRES.Application.DTOs;
using AdquisicionesADRES.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdquisicionesADRES.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoAdquisicionController : ControllerBase
    {
        private readonly TipoAdquisicionService _tipoService;

        public TipoAdquisicionController(TipoAdquisicionService tipoService)
        {
            _tipoService = tipoService;
        }

        // GET: api/TipoAdquisicion
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tipos = await _tipoService.ObtenerTiposAsync();
            return Ok(tipos);
        }

        // GET: api/TipoAdquisicion/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipo = await _tipoService.ObtenerTipoPorIdAsync(id);
            if (tipo == null) return NotFound();

            return Ok(tipo);
        }

        // POST: api/TipoAdquisicion
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoAdquisicionDto dto)
        {
            var nuevo = await _tipoService.CrearTipoAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        // PUT: api/TipoAdquisicion/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TipoAdquisicionDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID de ruta y cuerpo no coinciden.");

            var actualizado = await _tipoService.ActualizarTipoAsync(dto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        // DELETE: api/TipoAdquisicion/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _tipoService.EliminarTipoAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
