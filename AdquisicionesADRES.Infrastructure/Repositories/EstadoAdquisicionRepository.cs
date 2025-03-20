using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;
using AdquisicionesADRES.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdquisicionesADRES.Infrastructure.Repositories
{
    public class EstadoAdquisicionRepository : IEstadoAdquisicionRepository
    {
        private readonly AdquisicionesDbContext _context;

        public EstadoAdquisicionRepository(AdquisicionesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EstadoAdquisicion estado)
        {
            _context.EstadosAdquisicion.Add(estado);
            await _context.SaveChangesAsync();
        }

        public async Task<EstadoAdquisicion?> GetByIdAsync(int id)
        {
            return await _context.EstadosAdquisicion.FindAsync(id);
        }

        public async Task<List<EstadoAdquisicion>> GetAllAsync()
        {
            return await _context.EstadosAdquisicion.ToListAsync();
        }

        public async Task UpdateAsync(EstadoAdquisicion estado)
        {
            _context.EstadosAdquisicion.Update(estado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var estado = await _context.EstadosAdquisicion.FindAsync(id);
            if (estado != null)
            {
                _context.EstadosAdquisicion.Remove(estado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
