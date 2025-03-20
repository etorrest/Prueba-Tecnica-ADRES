using AdquisicionesADRES.Application.DTOs;
using AdquisicionesADRES.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdquisicionesADRES.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorService _proveedorService;

        public ProveedorController(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        // GET: api/Proveedor
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _proveedorService.ObtenerProveedoresAsync();
            return Ok(proveedores);
        }

        // GET: api/Proveedor/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proveedor = await _proveedorService.ObtenerProveedorPorIdAsync(id);
            if (proveedor == null) return NotFound();

            return Ok(proveedor);
        }

        // POST: api/Proveedor
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProveedorDto dto)
        {
            var nuevo = await _proveedorService.CrearProveedorAsync(dto);
            // Retornamos el objeto creado con su ID y un 201 Created
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        // PUT: api/Proveedor/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProveedorDto dto)
        {
            // Asegurar que el ID de la URL coincida con el del DTO (buena práctica)
            if (id != dto.Id)
                return BadRequest("El ID en la ruta y en el cuerpo no coinciden.");

            var actualizado = await _proveedorService.ActualizarProveedorAsync(dto);
            if (!actualizado) return NotFound();

            return NoContent(); // 204: Operación exitosa, sin contenido en el cuerpo
        }

        // DELETE: api/Proveedor/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _proveedorService.EliminarProveedorAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
