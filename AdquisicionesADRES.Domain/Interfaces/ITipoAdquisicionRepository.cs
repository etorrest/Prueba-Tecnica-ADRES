using AdquisicionesADRES.Domain.Entities;

namespace AdquisicionesADRES.Domain.Interfaces
{
    public interface ITipoAdquisicionRepository
    {
        Task AddAsync(TipoAdquisicion tipo);
        Task<TipoAdquisicion?> GetByIdAsync(int id);
        Task<List<TipoAdquisicion>> GetAllAsync();
        Task UpdateAsync(TipoAdquisicion tipo);
        Task DeleteAsync(int id);
    }
}
