using RunGym.Models;
namespace RunGym.Repositorios.Interfaces

{
    public interface IEjercicios
    {
        Task<List<Ejercicios>> GetEjercicios();

        Task<Ejercicios> GetEjerciciosById(int id);

        Task<Ejercicios> GetEjerciciosByName(string nombre);

        Task<bool> PostEjercicios(Ejercicios ejercicios);

        Task<bool> PutEjercicios(Ejercicios ejercicios);

        Task<bool> DeleteEjercicios(Ejercicios ejercicios);
    }
}
