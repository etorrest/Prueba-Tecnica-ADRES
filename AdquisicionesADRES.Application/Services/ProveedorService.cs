using AdquisicionesADRES.Application.DTOs;
using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;

namespace AdquisicionesADRES.Application.Services
{
    public class ProveedorService
    {
        private readonly IProveedorRepository _proveedorRepo;

        public ProveedorService(IProveedorRepository proveedorRepo)
        {
            _proveedorRepo = proveedorRepo;
        }

        // CREATE
        public async Task<ProveedorDto> CrearProveedorAsync(ProveedorDto dto)
        {
            // Mapear DTO a Entidad
            var proveedor = new Proveedor(dto.Id, dto.Nombre,dto.Nit);

            // Guardar en BD
            await _proveedorRepo.AddAsync(proveedor);

            // Retornar DTO actualizado (por si el ID lo asigna la DB)
            return new ProveedorDto
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Nit=proveedor.Nit
            };
        }

        // READ by ID
        public async Task<ProveedorDto?> ObtenerProveedorPorIdAsync(int id)
        {
            var proveedor = await _proveedorRepo.GetByIdAsync(id);
            if (proveedor == null) return null;

            // Mapear Entidad a DTO
            return new ProveedorDto
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Nit=proveedor.Nit
            };
        }

        // READ ALL
        public async Task<List<ProveedorDto>> ObtenerProveedoresAsync()
        {
            var proveedores = await _proveedorRepo.GetAllAsync();
            return proveedores
                .Select(p => new ProveedorDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Nit=p.Nit
                })
                .ToList();
        }

        // UPDATE
        public async Task<bool> ActualizarProveedorAsync(ProveedorDto dto)
        {
            // Buscar el proveedor en BD
            var proveedor = await _proveedorRepo.GetByIdAsync(dto.Id);
            if (proveedor == null) return false;

            // Actualizar y guardar
            proveedor.ActualizarDatos(dto.Nombre,dto.Nit);
            await _proveedorRepo.UpdateAsync(proveedor);

            return true;
        }

        // DELETE
        public async Task<bool> EliminarProveedorAsync(int id)
        {
            var proveedor = await _proveedorRepo.GetByIdAsync(id);
            if (proveedor == null) return false;

            await _proveedorRepo.DeleteAsync(id);
            return true;
        }
    }
}
