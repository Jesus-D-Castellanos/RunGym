using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;
namespace RunGym.Repositorios
{
    public class EjerciciosRepository : IEjercicios
    {
        private readonly RunGymContext context;

        public EjerciciosRepository(RunGymContext context)
        {
            this.context = context;
        }

        public async Task<List<Ejercicios>> GetEjercicios()
        {
            var data = await context.Ejercicios.ToListAsync();
            return data;
        }

        public async Task<Ejercicios> GetEjerciciosById(int id)
        {
            var data = await context.Ejercicios.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Ejercicios> GetEjerciciosByName(string nombre)
        {
            var data = await context.Ejercicios.Where(x => x.Nombre_Ejercicio == nombre).FirstOrDefaultAsync();
            return data;
        }
        public async Task<bool> PostEjercicios(Ejercicios ejercicios)
        {
            await context.Ejercicios.AddAsync(ejercicios);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutEjercicios(Ejercicios ejercicios)
        {
            context.Update(ejercicios);
            await context.SaveAsync();
            return true;

        }

        public async Task<bool> DeleteEjercicios(Ejercicios ejercicios)
        {
            context.Ejercicios.Remove(ejercicios);
            await context.SaveAsync();
            return true;
        }
    }
}
