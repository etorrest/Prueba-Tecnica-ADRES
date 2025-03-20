using AdquisicionesADRES.Application.DTOs;
using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;

namespace AdquisicionesADRES.Application.Services
{
    public class UnidadResponsableService
    {
        private readonly IUnidadResponsableRepository _unidadRepo;

        public UnidadResponsableService(IUnidadResponsableRepository unidadRepo)
        {
            _unidadRepo = unidadRepo;
        }

        // CREATE
        public async Task<UnidadResponsableDto> CrearUnidadResponsableAsync(UnidadResponsableDto dto)
        {
            var unidad = new UnidadResponsable(dto.Id, dto.Nombre);
            await _unidadRepo.AddAsync(unidad);

            return new UnidadResponsableDto
            {
                Id = unidad.Id,
                Nombre = unidad.Nombre
            };
        }

        // READ by ID
        public async Task<UnidadResponsableDto?> ObtenerUnidadPorIdAsync(int id)
        {
            var unidad = await _unidadRepo.GetByIdAsync(id);
            if (unidad == null) return null;

            return new UnidadResponsableDto
            {
                Id = unidad.Id,
                Nombre = unidad.Nombre
            };
        }

        // READ ALL
        public async Task<List<UnidadResponsableDto>> ObtenerUnidadesAsync()
        {
            var unidades = await _unidadRepo.GetAllAsync();
            return unidades
                .Select(u => new UnidadResponsableDto { Id = u.Id, Nombre = u.Nombre })
                .ToList();
        }

        // UPDATE
        public async Task<bool> ActualizarUnidadResponsableAsync(UnidadResponsableDto dto)
        {
            var unidad = await _unidadRepo.GetByIdAsync(dto.Id);
            if (unidad == null) return false;

            unidad.ActualizarNombre(dto.Nombre);
            await _unidadRepo.UpdateAsync(unidad);
            return true;
        }

        // DELETE
        public async Task<bool> EliminarUnidadResponsableAsync(int id)
        {
            var unidad = await _unidadRepo.GetByIdAsync(id);
            if (unidad == null) return false;

            await _unidadRepo.DeleteAsync(id);
            return true;
        }
    }
}
