using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AdquisicionesADRES.Infrastructure.Data
{
    public class AdquisicionesDbContextFactory : IDesignTimeDbContextFactory<AdquisicionesDbContext>
    {
        public AdquisicionesDbContext CreateDbContext(string[] args)
        {
            // 1. Construimos la configuración para leer appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                // (Opcional) Cargar también "appsettings.Development.json"
                .Build();

            // 2. Obtenemos la cadena de conexión
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 3. Creamos las opciones para el DbContext
            var builder = new DbContextOptionsBuilder<AdquisicionesDbContext>();
            builder.UseSqlServer(connectionString);

            // 4. Devolvemos una instancia del contexto con las opciones configuradas
            return new AdquisicionesDbContext(builder.Options);
        }
    }
}
