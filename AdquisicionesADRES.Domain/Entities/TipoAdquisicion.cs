using System.ComponentModel.DataAnnotations;

namespace AdquisicionesADRES.Domain.Entities
{
    /// <summary>
    /// Representa la tabla Catálogo para "Tipo de Adquisición"
    /// (Bienes, Servicios, Obras, etc.).
    /// </summary>
    public class TipoAdquisicion
    {
        [Key]
        public int Id { get; private set; }

        [Required, StringLength(80)]
        public string Nombre { get; private set; }

        // Constructor sin parámetros para EF
        private TipoAdquisicion() { }

        public TipoAdquisicion(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public void ActualizarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de TipoAdquisicion no puede ser vacío.");

            Nombre = nombre;
        }
    }
}
