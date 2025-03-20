using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;
using AdquisicionesADRES.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdquisicionesADRES.Infrastructure.Repositories
{
    public class UnidadResponsableRepository : IUnidadResponsableRepository
    {
        private readonly AdquisicionesDbContext _context;

        public UnidadResponsableRepository(AdquisicionesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UnidadResponsable unidad)
        {
            _context.UnidadesResponsables.Add(unidad);
            await _context.SaveChangesAsync();
        }

        public async Task<UnidadResponsable?> GetByIdAsync(int id)
        {
            return await _context.UnidadesResponsables.FindAsync(id);
        }

        public async Task<List<UnidadResponsable>> GetAllAsync()
        {
            return await _context.UnidadesResponsables.ToListAsync();
        }

        public async Task UpdateAsync(UnidadResponsable unidad)
        {
            _context.UnidadesResponsables.Update(unidad);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var unidad = await _context.UnidadesResponsables.FindAsync(id);
            if (unidad != null)
            {
                _context.UnidadesResponsables.Remove(unidad);
                await _context.SaveChangesAsync();
            }
        }
    }
}
