using AdquisicionesADRES.Application.Services;
using AdquisicionesADRES.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AdquisicionesController : ControllerBase
{
    private readonly AdquisicionService _service;

    public AdquisicionesController(AdquisicionService service)
    {
        _service = service;
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] AdquisicionDto dto)
    {
        var result = await _service.CrearAdquisicionAsync(dto);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = result.Id }, result);
    }

    // READ BY ID
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObtenerPorId(Guid id)
    {
        var adquisicion = await _service.ObtenerPorIdAsync(id);
        if (adquisicion == null) return NotFound();
        return Ok(adquisicion);
    }

    // READ ALL
    [HttpGet]
    public async Task<IActionResult> ObtenerTodas()
    {
        var lista = await _service.ObtenerTodasAsync();  // Ajusta al nombre real de tu método
        return Ok(lista);
    }

    // UPDATE
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Actualizar(Guid id, [FromBody] AdquisicionDto dto)
    {
        // Validar que el ID del DTO y el de la ruta coincidan
        if (id != dto.Id)
            return BadRequest("El ID de la ruta y el cuerpo no coinciden.");

        var exito = await _service.ActualizarAdquisicionAsync(dto);
        if (!exito)
            return NotFound(); // Por ejemplo, si la adquisición no existe en BD

        return NoContent(); // 204: Operación exitosa sin contenido
    }

    // DELETE
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Eliminar(Guid id)
    {
        var exito = await _service.EliminarAdquisicionAsync(id);
        if (!exito)
            return NotFound();

        return NoContent();
    }
}
