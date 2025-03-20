using AdquisicionesADRES.Application.DTOs;
using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;

namespace AdquisicionesADRES.Application.Services
{
    public class TipoAdquisicionService
    {
        private readonly ITipoAdquisicionRepository _tipoRepo;

        public TipoAdquisicionService(ITipoAdquisicionRepository tipoRepo)
        {
            _tipoRepo = tipoRepo;
        }

        // CREATE
        public async Task<TipoAdquisicionDto> CrearTipoAsync(TipoAdquisicionDto dto)
        {
            var tipo = new TipoAdquisicion(dto.Id, dto.Nombre);
            await _tipoRepo.AddAsync(tipo);

            return new TipoAdquisicionDto
            {
                Id = tipo.Id,
                Nombre = tipo.Nombre
            };
        }

        // READ by ID
        public async Task<TipoAdquisicionDto?> ObtenerTipoPorIdAsync(int id)
        {
            var tipo = await _tipoRepo.GetByIdAsync(id);
            if (tipo == null) return null;

            return new TipoAdquisicionDto
            {
                Id = tipo.Id,
                Nombre = tipo.Nombre
            };
        }

        // READ ALL
        public async Task<List<TipoAdquisicionDto>> ObtenerTiposAsync()
        {
            var tipos = await _tipoRepo.GetAllAsync();
            return tipos
                .Select(t => new TipoAdquisicionDto { Id = t.Id, Nombre = t.Nombre })
                .ToList();
        }

        // UPDATE
        public async Task<bool> ActualizarTipoAsync(TipoAdquisicionDto dto)
        {
            var tipo = await _tipoRepo.GetByIdAsync(dto.Id);
            if (tipo == null) return false;

            tipo.ActualizarNombre(dto.Nombre);
            await _tipoRepo.UpdateAsync(tipo);
            return true;
        }

        // DELETE
        public async Task<bool> EliminarTipoAsync(int id)
        {
            var tipo = await _tipoRepo.GetByIdAsync(id);
            if (tipo == null) return false;

            await _tipoRepo.DeleteAsync(id);
            return true;
        }
    }
}
