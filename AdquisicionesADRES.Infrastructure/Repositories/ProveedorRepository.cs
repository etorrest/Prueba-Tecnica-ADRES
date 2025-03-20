using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;
using AdquisicionesADRES.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdquisicionesADRES.Infrastructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly AdquisicionesDbContext _context;

        public ProveedorRepository(AdquisicionesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Proveedor?> GetByIdAsync(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task UpdateAsync(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
