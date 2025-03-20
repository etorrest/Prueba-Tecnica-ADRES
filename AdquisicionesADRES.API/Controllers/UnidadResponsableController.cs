using AdquisicionesADRES.Application.DTOs;
using AdquisicionesADRES.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdquisicionesADRES.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadResponsableController : ControllerBase
    {
        private readonly UnidadResponsableService _unidadService;

        public UnidadResponsableController(UnidadResponsableService unidadService)
        {
            _unidadService = unidadService;
        }

        // GET: api/UnidadResponsable
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var unidades = await _unidadService.ObtenerUnidadesAsync();
            return Ok(unidades);
        }

        // GET: api/UnidadResponsable/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var unidad = await _unidadService.ObtenerUnidadPorIdAsync(id);
            if (unidad == null) return NotFound();

            return Ok(unidad);
        }

        // POST: api/UnidadResponsable
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UnidadResponsableDto dto)
        {
            var nueva = await _unidadService.CrearUnidadResponsableAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nueva.Id }, nueva);
        }

        // PUT: api/UnidadResponsable/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UnidadResponsableDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID no coincide con el DTO.");

            var actualizado = await _unidadService.ActualizarUnidadResponsableAsync(dto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        // DELETE: api/UnidadResponsable/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _unidadService.EliminarUnidadResponsableAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
