using AdquisicionesADRES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdquisicionesADRES.Domain.Interfaces
{
    public interface IModuloRepository
    {
        Task<List<Modulo>> GetAllAsync();

    }
}
