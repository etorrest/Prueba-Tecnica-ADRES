using AdquisicionesADRES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdquisicionesADRES.Domain.Interfaces
{
    public interface IAdquisicionRepository
    {
        Task AddAsync(Adquisicion adquisicion);
        Task<Adquisicion?> GetByIdAsync(Guid id);
        Task UpdateAsync(Adquisicion adquisicion);
        Task DeleteAsync(Guid id);
        Task<List<Adquisicion>> GetAllAsync();
        // Otros métodos de consulta/filtrado...
    }

}
