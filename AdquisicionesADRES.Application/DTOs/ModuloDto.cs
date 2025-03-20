using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdquisicionesADRES.Application.DTOs
{
    public class ModuloDto
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, StringLength(60)]
        public string Titulo { get; set; } = string.Empty;
        [Required, StringLength(600)]
        public string Descripcion { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string Icono { get; set; } = string.Empty;
        [Required, StringLength(60)]

        public string Enlace { get; set; } = string.Empty;
        public int Orden { get; set; } = 1;

    }
}
