using RunGym.Models;
namespace RunGym.Repositorios.Interfaces
{
    public interface IUsuarios
    {
        Task<List<Usuarios>> GetUsuarios();
        Task<bool> PostUsuarios(Usuarios usuarios);
        Task<bool> PutUsuarios(Usuarios usuarios);
        Task<bool> DeleteUsuarios(int id);
    }
}
