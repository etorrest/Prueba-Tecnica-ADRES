using AdquisicionesADRES.Domain.Entities;
using AdquisicionesADRES.Domain.Interfaces;
using AdquisicionesADRES.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdquisicionesADRES.Infrastructure.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly AdquisicionesDbContext _context;

        public ModuloRepository(AdquisicionesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Modulo>> GetAllAsync()
        {
            return  await _context.Modulo.ToListAsync();
        }
        
    }
}
