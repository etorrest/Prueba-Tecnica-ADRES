using System.ComponentModel.DataAnnotations;

namespace AdquisicionesADRES.Domain.Entities
{
    /// <summary>
    /// Representa la tabla para el estado de la Adquisición:
    /// "Creado", "EnEjecucion", "Finalizado", "Cancelado", etc.
    /// </summary>
    public class EstadoAdquisicion
    {
        [Key]
        public int Id { get; private set; }

        [Required, StringLength(80)]

        public string Nombre { get; private set; }

        private EstadoAdquisicion() { }

        public EstadoAdquisicion(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public void ActualizarNombre(string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre del Estado no puede ser vacío.");

            Nombre = nuevoNombre;
        }
    }
}
