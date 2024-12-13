using RunGym.Models;
namespace RunGym.Repositorios.Interfaces
{
    public interface IRutinasEjercicios
    {
        Task<List<RutinasEjercicio>> GetRutinasEjercicio();

        Task<RutinasEjercicio> GetRutinasEjercicioById(int id);

        Task<RutinasEjercicio> GetRutinasEjercicioByName(string nombre);

        Task<bool> PostRutinasEjercicio(RutinasEjercicio rutinasEjercicio);

        Task<bool> PutRutinasEjercicio(RutinasEjercicio rutinasEjercicio);

        Task<bool> DeleteRutinasEjercicio(RutinasEjercicio rutinasEjercicio);
    }
}
