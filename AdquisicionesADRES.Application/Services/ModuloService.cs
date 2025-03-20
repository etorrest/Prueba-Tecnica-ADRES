using AdquisicionesADRES.Application.DTOs;
using AdquisicionesADRES.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdquisicionesADRES.Application.Services
{
    public class ModuloService
    {

        private readonly IModuloRepository _moduloRepository;

        public ModuloService(IModuloRepository moduloRepository)
        {
            _moduloRepository = moduloRepository;
        }


        // READ ALL
        public async Task<List<ModuloDto>> ObtenerModulosAsync()
        {
            var proveedores = await _moduloRepository.GetAllAsync();
            return proveedores
                .Select(p => new ModuloDto
                {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    Descripcion = p.Descripcion,
                    Icono = p.Icono,
                    Enlace = p.Enlace,
                    Orden = p.Orden

                }).OrderBy(p=>p.Orden)
                .ToList();
        }

    }
}
