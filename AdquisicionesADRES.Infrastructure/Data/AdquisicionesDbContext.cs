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
        public DbSet<Modulo> Modulo{ get; set; } = null!;

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
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedor");
                entity.HasKey(p => p.Id);
            });

            modelBuilder.Entity<UnidadResponsable>(entity =>
            {
                entity.ToTable("UnidadResponsable");
                entity.HasKey(u => u.Id);
            });

            modelBuilder.Entity<EstadoAdquisicion>(entity =>
            {
                entity.ToTable("EstadoAdquisicion");
                entity.HasKey(e => e.Id);
            });


            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("Modulo");
                entity.HasKey(m => m.Id);
            });
        }
    }
}
