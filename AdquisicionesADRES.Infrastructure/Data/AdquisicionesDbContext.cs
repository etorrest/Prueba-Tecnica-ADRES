// Data/AdquisicionesDbContext.cs
using AdquisicionesADRES.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdquisicionesADRES.Infrastructure.Data
{
    public class AdquisicionesDbContext : DbContext
    {
        // Define DbSet<T> para cada entidad
        public DbSet<Adquisicion> Adquisiciones { get; set; } = null!;
        public DbSet<TipoAdquisicion> TiposAdquisicion { get; set; } = null!;
        public DbSet<Proveedor> Proveedores { get; set; } = null!;
        public DbSet<UnidadResponsable> UnidadesResponsables { get; set; } = null!;
        public DbSet<EstadoAdquisicion> EstadosAdquisicion { get; set; } = null!;
        public DbSet<Modulo> Modulo { get; set; } = null!;

        public AdquisicionesDbContext(DbContextOptions<AdquisicionesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales de EF Core (Fluent API)
            // Por ejemplo:
            modelBuilder.Entity<Adquisicion>(entity =>
            {
                entity.ToTable("Adquisicion");
                entity.HasKey(a => a.Id);

                // Relaciones (FK)
                entity.HasOne(a => a.Tipo)
                      .WithMany()
                      .HasForeignKey(a => a.TipoAdquisicionId);

                entity.HasOne(a => a.Estado)
                      .WithMany()
                      .HasForeignKey(a => a.EstadoAdquisicionId);

                entity.HasOne(a => a.Proveedor)
                      .WithMany()
                      .HasForeignKey(a => a.ProveedorId);

                entity.HasOne(a => a.UnidadResponsable)
                      .WithMany()
                      .HasForeignKey(a => a.UnidadResponsableId);
            });

            modelBuilder.Entity<TipoAdquisicion>(entity =>
            {
                entity.ToTable("TipoAdquisicion");
                entity.HasKey(t => t.Id);
                entity.HasData(
                    new TipoAdquisicion { Id = 1, Nombre = "Bienes" },
                    new TipoAdquisicion { Id = 2, Nombre = "Servicios" },
                    new TipoAdquisicion { Id = 3, Nombre = "Obras" }
                );
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedor");
                entity.HasKey(p => p.Id);
                entity.HasData(
                    new Proveedor { Id = 1, Nombre = "Laboratorios Bayer S.A.", Nit = "900500234-1" },
                    new Proveedor { Id = 2, Nombre = "Laboratorio  Bioprocesos Colombia", Nit = "900495029-1"},
                    new Proveedor { Id = 3, Nombre = "Dispensador MEDIMAX" , Nit = "900395923-1" }
                );
            });

            modelBuilder.Entity<UnidadResponsable>(entity =>
            {
                entity.ToTable("UnidadResponsable");
                entity.HasKey(u => u.Id);
                entity.HasData(
                    new UnidadResponsable { Id = 1, Nombre = "Subdireccion Financiera" },
                    new UnidadResponsable { Id = 2, Nombre = "Dirección de Medicamentos y Tecnologías en Salud " },
                    new UnidadResponsable { Id = 3, Nombre = "Subdireccion Administrativa" }
                );
            });

            modelBuilder.Entity<EstadoAdquisicion>(entity =>
            {
                entity.ToTable("EstadoAdquisicion");
                entity.HasKey(e => e.Id);
                entity.HasData(
                    new EstadoAdquisicion { Id = 1, Nombre = "Creada" },
                    new EstadoAdquisicion { Id = 2, Nombre = "En Ejecucion" },
                    new EstadoAdquisicion { Id = 3, Nombre = "Finalizada" },
                    new EstadoAdquisicion { Id = 4, Nombre = "Cancelada" }
                );
            });


            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("Modulo");
                entity.HasKey(m => m.Id);
            });

            modelBuilder.Entity<Modulo>().HasData(
            new Modulo
            {
                // Asigna un GUID fijo para evitar conflictos en múltiples migraciones
                Id = Guid.Parse("64AC3033-266B-424A-99FA-1127B29828FE"),
                Titulo = "PROVEEDORES",
                Descripcion = "Permite la consulta, adición y actualización de proveedores.",
                Icono = "proveedor.png",
                Enlace = "/proveedores",
                Orden = 2
            },
            new Modulo
            {
                Id = Guid.Parse("965FB6A6-6EC6-4908-A130-5A85CDA98D97"),
                Titulo = "ADQUISICIONES",
                Descripcion = "Permite la gestión integral de registro de solicitudes de adquisiciones",
                Icono = "mrecibir.png",
                Enlace = "/adquisiciones",
                Orden = 1
            },
            new Modulo
            {
                Id = Guid.Parse("91E8FA40-74BE-4AAC-B886-C463D86F9EEA"),
                Titulo = "MANTENIMIENTO DE TABLAS",
                Descripcion = "Permite el mantenimiento de tablas de referencia (crear y modificar) ",
                Icono = "ajustes.png",
                Enlace = "/ajustes",
                Orden = 3
            }
             );
        }
    }
}
