// DTOs/AdquisicionDto.cs
namespace AdquisicionesADRES.Application.DTOs
{
    public class AdquisicionDto
    {
        public Guid Id { get; set; }

        public int TipoAdquisicionId { get; set; }
        public TipoAdquisicionDto? TipoAdquisicion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal ValorUnitarios { get; set; }
        public decimal Presupuesto { get; set; }

        public int UnidadResponsableId { get; set; }
        public UnidadResponsableDto? UnidadResponsable { get; set; }
        public int ProveedorId { get; set; }
        // DTO completo del proveedor
        public ProveedorDto? Proveedor { get; set; }

        public DateTime? FechaAdquisicion { get; set; }

        public int EstadoAdquisicionId { get; set; }
        public EstadoAdquisicionDto? EstadoAdquisicion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }


    }
}
