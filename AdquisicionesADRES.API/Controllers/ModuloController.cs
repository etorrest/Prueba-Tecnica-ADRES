using AdquisicionesADRES.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdquisicionesADRES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {

        private readonly ModuloService _moduloService;
        public ModuloController(ModuloService moduloService)
        {
            _moduloService = moduloService;
        }


        // GET: api/Modulo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _moduloService.ObtenerModulosAsync();
            return Ok(proveedores);
        }
    }
}
