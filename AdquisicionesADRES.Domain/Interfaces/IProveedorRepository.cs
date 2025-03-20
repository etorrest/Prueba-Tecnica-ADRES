using AdquisicionesADRES.Domain.Entities;

namespace AdquisicionesADRES.Domain.Interfaces
{
    public interface IProveedorRepository
    {
        Task AddAsync(Proveedor proveedor);
        Task<Proveedor?> GetByIdAsync(int id);
        Task<List<Proveedor>> GetAllAsync();
        Task UpdateAsync(Proveedor proveedor);
        Task DeleteAsync(int id);
    }
}
