using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;
using AdquisicionesADRES.Application.DTOs;

namespace AdquisicionesADRES.Application.Services
{
    public class AdquisicionService
    {
        private readonly IAdquisicionRepository _adquisicionRepo;
        // Si tienes repositorios para las otras entidades (Proveedor, TipoAdquisicion, etc.)
        // inyectarlos también y obtenerlos de la BD en vez de crearlos "al vuelo".

        public AdquisicionService(IAdquisicionRepository adquisicionRepo)
        {
            _adquisicionRepo = adquisicionRepo;
        }

        // CREATE
        public async Task<AdquisicionDto> CrearAdquisicionAsync(AdquisicionDto dto)
        {
            // Crear la entidad de dominio (aquí se asume que los catálogos existen)
            var adquisicion = new Adquisicion(
                descripcion: dto.Descripcion,
                cantidad: dto.Cantidad,
                valorUnitarios: dto.ValorUnitarios,
                presupuesto: dto.Presupuesto,
                tipoAdquisicionId: dto.TipoAdquisicionId,
                proveedorId: dto.ProveedorId,
                unidadResponsableId: dto.UnidadResponsableId,
                estadoAdquisicionId: dto.EstadoAdquisicionId,
                fechaAdquisicion: dto.FechaAdquisicion
            );

            await _adquisicionRepo.AddAsync(adquisicion);

            // Retornar mapeo a DTO
            return new AdquisicionDto
            {
                Id = adquisicion.Id,
                TipoAdquisicionId = adquisicion.TipoAdquisicionId,
                Descripcion = adquisicion.Descripcion,
                Cantidad = adquisicion.Cantidad,
                ValorUnitarios = adquisicion.ValorUnitarios,
                Presupuesto = adquisicion.Presupuesto,
                UnidadResponsableId = adquisicion.UnidadResponsableId,
                ProveedorId = adquisicion.ProveedorId,
                EstadoAdquisicionId = adquisicion.EstadoAdquisicionId,
                FechaAdquisicion = adquisicion.FechaAdquisicion,
                FechaCreacion = adquisicion.FechaCreacion,
                FechaModificacion = adquisicion.FechaModificacion
            };
        }

        // READ (Obtener por Id)
        public async Task<AdquisicionDto?> ObtenerPorIdAsync(Guid id)
        {
            var adquisicion = await _adquisicionRepo.GetByIdAsync(id);
            if (adquisicion == null) return null;

            // Mapeo manual a DTO
            return new AdquisicionDto
            {
                Id = adquisicion.Id,
                TipoAdquisicionId = adquisicion.TipoAdquisicionId,
                TipoAdquisicion = new TipoAdquisicionDto { Id = adquisicion.Tipo.Id, Nombre = adquisicion.Tipo.Nombre },
                Descripcion = adquisicion.Descripcion,
                Cantidad = adquisicion.Cantidad,
                ValorUnitarios = adquisicion.ValorUnitarios,
                Presupuesto = adquisicion.Presupuesto,
                UnidadResponsableId = adquisicion.UnidadResponsableId,
                UnidadResponsable = new UnidadResponsableDto { Id = adquisicion.UnidadResponsable.Id, Nombre = adquisicion.UnidadResponsable.Nombre },
                ProveedorId = adquisicion.ProveedorId,
                Proveedor = new ProveedorDto { Id = adquisicion.Proveedor.Id, Nombre = adquisicion.Proveedor.Nombre },
                EstadoAdquisicionId = adquisicion.EstadoAdquisicionId,
                EstadoAdquisicion = new EstadoAdquisicionDto { Id = adquisicion.Estado.Id, Nombre = adquisicion.Estado.Nombre },
                FechaAdquisicion = adquisicion.FechaAdquisicion,
                FechaCreacion = adquisicion.FechaCreacion,
                FechaModificacion = adquisicion.FechaModificacion
            };
        }

        // READ (Obtener todas)
        public async Task<List<AdquisicionDto>> ObtenerTodasAsync()
        {
            // Debes tener un método GetAllAsync() en tu repositorio
            var adquisiciones = await _adquisicionRepo.GetAllAsync();

            // Mapeo a lista de DTO
            var listaDto = adquisiciones.Select(a => new AdquisicionDto
            {
                Id = a.Id,
                TipoAdquisicionId = a.TipoAdquisicionId,
                TipoAdquisicion = new TipoAdquisicionDto { Id = a.Tipo.Id, Nombre = a.Tipo.Nombre },
                Descripcion = a.Descripcion,
                Cantidad = a.Cantidad,
                ValorUnitarios = a.ValorUnitarios,
                Presupuesto = a.Presupuesto,
                UnidadResponsableId = a.UnidadResponsableId,
                UnidadResponsable = new UnidadResponsableDto { Id = a.UnidadResponsable.Id, Nombre = a.UnidadResponsable.Nombre },
                ProveedorId = a.ProveedorId,
                Proveedor = new ProveedorDto { Id = a.Proveedor.Id, Nombre = a.Proveedor.Nombre },
                EstadoAdquisicionId = a.EstadoAdquisicionId,
                EstadoAdquisicion = new EstadoAdquisicionDto { Id = a.Estado.Id, Nombre = a.Estado.Nombre },
                FechaAdquisicion = a.FechaAdquisicion,
                FechaCreacion = a.FechaCreacion,
                FechaModificacion = a.FechaModificacion
            }).ToList();

            return listaDto;
        }

        // UPDATE
        public async Task<bool> ActualizarAdquisicionAsync(AdquisicionDto dto)
        {
            // Buscar la entidad en BD
            var adquisicion = await _adquisicionRepo.GetByIdAsync(dto.Id);
            if (adquisicion == null) return false;

            // Aquí deberías mapear los nuevos datos al dominio. 
            // Si tu entidad de dominio tiene un método "Actualizar" o "SetDatos", úsalo. 
            // Por ejemplo, si en la clase Adquisicion existe un método "Actualizar(...)":
            adquisicion.Actualizar(
                descripcion: dto.Descripcion,
                cantidad: dto.Cantidad,
                valorUnitarios: dto.ValorUnitarios,
                presupuesto: dto.Presupuesto,
                tipoAdquisicionId: dto.TipoAdquisicionId,
                proveedorId: dto.ProveedorId,
                unidadResponsableId: dto.UnidadResponsableId,
                estadoAdquisicionId: dto.EstadoAdquisicionId,
                fechaAdquisicion: dto.FechaAdquisicion
            );

            // Guardar cambios
            await _adquisicionRepo.UpdateAsync(adquisicion);
            return true;
        }

        // DELETE
        public async Task<bool> EliminarAdquisicionAsync(Guid id)
        {
            var adquisicion = await _adquisicionRepo.GetByIdAsync(id);
            if (adquisicion == null) return false;

            await _adquisicionRepo.DeleteAsync(id);
            return true;
        }
    }
}
