using System.ComponentModel.DataAnnotations;

namespace AdquisicionesADRES.Domain.Entities
{
    public class Adquisicion
    {
        public Guid Id { get; private set; }

        // Claves foráneas y propiedades de navegación para cada Tipo Adquisicion
        public int TipoAdquisicionId { get; private set; }
        public TipoAdquisicion Tipo { get;  set; }

        [Required, StringLength(200)]
        public string Descripcion { get; private set; }
        public int Cantidad { get; private set; }
        public decimal ValorUnitarios { get; private set; }
        public decimal Presupuesto { get; private set; }

        public int UnidadResponsableId { get;  set; }
        public UnidadResponsable UnidadResponsable { get; private set; }

        public int ProveedorId { get;  set; }
        public Proveedor Proveedor { get; private set; }

        public DateTime? FechaAdquisicion { get; private set; }

        // Referencia a la clase EstadoAdquisicion 
        public int EstadoAdquisicionId { get;  set; }
        public EstadoAdquisicion Estado { get; private set; }

        public DateTime FechaCreacion { get; private set; } = DateTime.Now;
        public DateTime FechaModificacion { get; private set; }

        // Método de dominio para calcular el valor total
        public decimal ValorTotal()
        {
            return Cantidad * ValorUnitarios;
        }

        // Constructor sin parámetros para EF / serialización
        private Adquisicion()
        {
            // Requerido por EF
        }

        /// <summary>
        /// Constructor principal para crear una nueva adquisición.
        /// </summary>
        public Adquisicion(
            string descripcion,
            int cantidad,
            decimal valorUnitarios,
            decimal presupuesto,
            int tipoAdquisicionId,
            int proveedorId,
            int unidadResponsableId,
            int estadoAdquisicionId,
            DateTime? fechaAdquisicion = null

            )
        {
            Id = Guid.NewGuid();

            SetDatos(
                descripcion,
                cantidad,
                valorUnitarios,
                presupuesto,
                tipoAdquisicionId,
                proveedorId,
                unidadResponsableId,
                estadoAdquisicionId,
                fechaAdquisicion
            );

            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
        }

        /// <summary>
        /// Método para actualizar datos y refrescar la fecha de modificación.
        /// </summary>
        public void Actualizar(
            string descripcion,
            int cantidad,
            decimal valorUnitarios,
            decimal presupuesto,
            int tipoAdquisicionId,
            int proveedorId,
            int unidadResponsableId,
            int estadoAdquisicionId,
            DateTime? fechaAdquisicion)
        {
            SetDatos(
                descripcion,
                cantidad,
                valorUnitarios,
                presupuesto,
                tipoAdquisicionId,
                proveedorId,
                unidadResponsableId,
                estadoAdquisicionId,
                fechaAdquisicion
            );

            FechaModificacion = DateTime.Now;
        }

        /// <summary>
        /// Encapsula la lógica de asignar propiedades con validaciones de negocio.
        /// </summary>
        private void SetDatos(
            string descripcion,
            int cantidad,
            decimal valorUnitarios,
            decimal presupuesto,
            int tipoAdquisicionId,
            int proveedorId,
            int unidadResponsableId,
            int estadoAdquisicionId,
            DateTime? fechaAdquisicion
            )
        {
          

            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía o nula.");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            if (valorUnitarios <= 0)
                throw new ArgumentException("El valor unitario debe ser mayor que cero.");

            if (presupuesto < 0)
                throw new ArgumentException("El presupuesto no puede ser negativo.");

            


            Descripcion = descripcion;
            Cantidad = cantidad;
            ValorUnitarios = valorUnitarios;
            Presupuesto = presupuesto;
            TipoAdquisicionId = tipoAdquisicionId;
            ProveedorId = proveedorId;
            EstadoAdquisicionId = estadoAdquisicionId;
            UnidadResponsableId = unidadResponsableId;
            FechaAdquisicion = fechaAdquisicion;
        }
    }
}
