using System.ComponentModel.DataAnnotations;

namespace AdquisicionesADRES.Domain.Entities
{
    /// <summary>
    /// Representa la tabla de Proveedores para la Adquisición.
    /// </summary>
    public class Proveedor
    {
        [Key]
        public int Id { get;  set; }

        [StringLength(11), Required]
        public string Nit { get;  set; }


        [StringLength (100),Required]
        public string Nombre { get;  set; }
        public Proveedor() { }

        public Proveedor(int id, string nombre, string nit )
        {
            Id = id;
            Nombre = nombre;
            Nit = nit;
        }

        public void ActualizarDatos(string nuevoNombre,string nuevoNit)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre del Proveedor no puede ser vacío.");

            if (string.IsNullOrWhiteSpace(nuevoNit))
                throw new ArgumentException("El NIT del Proveedor no puede ser vacío.");


            Nombre = nuevoNombre;
            Nit = nuevoNit;
        }
    }
}
