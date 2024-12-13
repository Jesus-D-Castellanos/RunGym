using RunGym.Repositorios;
using RunGym.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;

namespace RunGym.API
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = _configuration["ConnectionStrings:SQLConnectionStrings"];

            services.AddDbContext<RunGymContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUsuarios, UsuariosRepository>();
            services.AddScoped<IRutinasEjercicios, RutinasEjercicioRepository>();
            services.AddScoped<IMetas, MetasRepository>();
            services.AddScoped<IEjercicios, EjerciciosRepository>();
            services.AddScoped<IDieta, DietaRepository>();
            services.AddScoped<IComidas, ComidasRepository>();

            return services;
        }
    }
}
