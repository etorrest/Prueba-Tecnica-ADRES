using AdquisicionesADRES.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdquisicionesADRES.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registrar servicios
            services.AddScoped<AdquisicionService>();
            services.AddScoped<ProveedorService>();
            services.AddScoped<TipoAdquisicionService>();
            services.AddScoped<EstadoAdquisicionService>();
            services.AddScoped<UnidadResponsableService>();
            services.AddScoped<ModuloService>();



            return services;
        }
    }
}
