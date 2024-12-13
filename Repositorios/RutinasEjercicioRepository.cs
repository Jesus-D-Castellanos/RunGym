using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;
namespace RunGym.Repositorios
{
    public class RutinasEjercicioRepository : IRutinasEjercicios
    {
        private readonly RunGymContext context;

        public RutinasEjercicioRepository(RunGymContext context)
        {
            this.context = context;
        }

        public async Task<List<RutinasEjercicio>> GetRutinasEjercicio()
        {
            var data = await context.RutinasEjercicio.ToListAsync();
            return data;
        }

        public async Task<RutinasEjercicio> GetRutinasEjercicioById(int id)
        {
            var data = await context.RutinasEjercicio.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<RutinasEjercicio> GetRutinasEjercicioByName(string nombre)
        {
            var data = await context.RutinasEjercicio.Where(x => x.NombreRutina == nombre).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostRutinasEjercicio(RutinasEjercicio rutinasEjercicio)
        {
            await context.RutinasEjercicio.AddAsync(rutinasEjercicio);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutRutinasEjercicio(RutinasEjercicio rutinasEjercicio)
        {
            context.Update(rutinasEjercicio);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteRutinasEjercicio(RutinasEjercicio rutinasEjercicio)
        {
            context.RutinasEjercicio.Remove(rutinasEjercicio);
            await context.SaveAsync();
            return true;
        }

        
    }
}
