using AdquisicionesADRES.Domain.Entities;

namespace AdquisicionesADRES.Domain.Interfaces
{
    public interface IEstadoAdquisicionRepository
    {
        Task AddAsync(EstadoAdquisicion estado);
        Task<EstadoAdquisicion?> GetByIdAsync(int id);
        Task<List<EstadoAdquisicion>> GetAllAsync();
        Task UpdateAsync(EstadoAdquisicion estado);
        Task DeleteAsync(int id);
    }
}

