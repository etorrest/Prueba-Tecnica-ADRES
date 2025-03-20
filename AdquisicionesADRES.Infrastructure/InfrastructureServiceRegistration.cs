using System;
using System.Collections.Generic;
using AdquisicionesADRES.Domain.Interfaces;
using AdquisicionesADRES.Infrastructure.Data;
using AdquisicionesADRES.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdquisicionesADRES.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // 1. Configurar la cadena de conexión
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 2. Registrar el DbContext con SQL Server (o la BD que uses)
            services.AddDbContext<AdquisicionesDbContext>(options =>
                options.UseSqlServer(connectionString));

            // 3. Registrar los repositorios
            services.AddScoped<IAdquisicionRepository, AdquisicionRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<ITipoAdquisicionRepository, TipoAdquisicionRepository>();
            services.AddScoped<IEstadoAdquisicionRepository, EstadoAdquisicionRepository>();
            services.AddScoped<IUnidadResponsableRepository, UnidadResponsableRepository>();
            services.AddScoped<IModuloRepository, ModuloRepository>();

            return services;
        }
    }
}
