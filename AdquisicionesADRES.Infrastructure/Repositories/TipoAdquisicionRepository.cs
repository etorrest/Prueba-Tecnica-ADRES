using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;
using AdquisicionesADRES.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdquisicionesADRES.Infrastructure.Repositories
{
    public class TipoAdquisicionRepository : ITipoAdquisicionRepository
    {
        private readonly AdquisicionesDbContext _context;

        public TipoAdquisicionRepository(AdquisicionesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TipoAdquisicion tipo)
        {
            _context.TiposAdquisicion.Add(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoAdquisicion?> GetByIdAsync(int id)
        {
            return await _context.TiposAdquisicion.FindAsync(id);
        }

        public async Task<List<TipoAdquisicion>> GetAllAsync()
        {
            return await _context.TiposAdquisicion.ToListAsync();
        }

        public async Task UpdateAsync(TipoAdquisicion tipo)
        {
            _context.TiposAdquisicion.Update(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tipo = await _context.TiposAdquisicion.FindAsync(id);
            if (tipo != null)
            {
                _context.TiposAdquisicion.Remove(tipo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
