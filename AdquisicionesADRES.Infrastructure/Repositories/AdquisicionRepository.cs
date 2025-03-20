using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;
using AdquisicionesADRES.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdquisicionesADRES.Infrastructure.Repositories
{
    public class AdquisicionRepository : IAdquisicionRepository
    {
        private readonly AdquisicionesDbContext _context;

        public AdquisicionRepository(AdquisicionesDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task AddAsync(Adquisicion adquisicion)
        {
            try
            {

                _context.Adquisiciones.Add(adquisicion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        // READ BY ID
        public async Task<Adquisicion?> GetByIdAsync(Guid id)
        {
            return await _context.Adquisiciones
                .Include(a => a.Tipo)
                .Include(a => a.Proveedor)
                .Include(a => a.UnidadResponsable)
                .Include(a => a.Estado)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // READ ALL (Método faltante)
        public async Task<List<Adquisicion>> GetAllAsync()
        {
            return await _context.Adquisiciones
                .Include(a => a.Tipo)
                .Include(a => a.Proveedor)
                .Include(a => a.UnidadResponsable)
                .Include(a => a.Estado)
                .ToListAsync();
        }

        // UPDATE
        public async Task UpdateAsync(Adquisicion adquisicion)
        {
            // EF Core rastrea los cambios automáticamente
            _context.Adquisiciones.Update(adquisicion);
            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(Guid id)
        {
            var adquisicion = await _context.Adquisiciones.FindAsync(id);
            if (adquisicion != null)
            {
                _context.Adquisiciones.Remove(adquisicion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
