using AdquisicionesADRES.Domain.Entities;

namespace AdquisicionesADRES.Domain.Interfaces
{
    public interface IUnidadResponsableRepository
    {
        Task AddAsync(UnidadResponsable unidad);
        Task<UnidadResponsable?> GetByIdAsync(int id);
        Task<List<UnidadResponsable>> GetAllAsync();
        Task UpdateAsync(UnidadResponsable unidad);
        Task DeleteAsync(int id);
    }
}
