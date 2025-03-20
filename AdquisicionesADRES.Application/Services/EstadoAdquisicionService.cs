using AdquisicionesADRES.Application.DTOs;
using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;

namespace AdquisicionesADRES.Application.Services
{
    public class EstadoAdquisicionService
    {
        private readonly IEstadoAdquisicionRepository _estadoRepo;

        public EstadoAdquisicionService(IEstadoAdquisicionRepository estadoRepo)
        {
            _estadoRepo = estadoRepo;
        }

        // CREATE
        public async Task<EstadoAdquisicionDto> CrearEstadoAsync(EstadoAdquisicionDto dto)
        {
            var estado = new EstadoAdquisicion(0, dto.Nombre);
            await _estadoRepo.AddAsync(estado);

            return new EstadoAdquisicionDto
            {
                Id = estado.Id,
                Nombre = estado.Nombre
            };
        }

        // READ
        public async Task<EstadoAdquisicionDto?> ObtenerEstadoPorIdAsync(int id)
        {
            var estado = await _estadoRepo.GetByIdAsync(id);
            if (estado == null) return null;

            return new EstadoAdquisicionDto
            {
                Id = estado.Id,
                Nombre = estado.Nombre
            };
        }

        // READ ALL
        public async Task<List<EstadoAdquisicionDto>> ObtenerEstadosAsync()
        {
            var estados = await _estadoRepo.GetAllAsync();
            return estados
                .Select(e => new EstadoAdquisicionDto { Id = e.Id, Nombre = e.Nombre })
                .ToList();
        }

        // UPDATE
        public async Task<bool> ActualizarEstadoAsync(EstadoAdquisicionDto dto)
        {
            var estado = await _estadoRepo.GetByIdAsync(dto.Id);
            if (estado == null) return false;

            estado.ActualizarNombre(dto.Nombre);
            await _estadoRepo.UpdateAsync(estado);
            return true;
        }

        // DELETE
        public async Task<bool> EliminarEstadoAsync(int id)
        {
            var estado = await _estadoRepo.GetByIdAsync(id);
            if (estado == null) return false;

            await _estadoRepo.DeleteAsync(id);
            return true;
        }
    }
}
