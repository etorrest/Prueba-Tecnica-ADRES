using System.ComponentModel.DataAnnotations;

namespace AdquisicionesADRES.Domain.Entities
{
    /// <summary>
    /// Tabla que define la subdirección o unidad responsable:
    /// "SubdireccionFinanciera", "SubdireccionTecnica", etc.
    /// </summary>
    public class UnidadResponsable
    {
        [Key]
        public int Id { get; set; }
        
        [Required, StringLength(80)]
        public string Nombre { get;  set; }


        public UnidadResponsable() { }

        public UnidadResponsable(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public void ActualizarNombre(string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre de la Unidad Responsable no puede ser vacío.");

            Nombre = nuevoNombre;
        }
    }
}
