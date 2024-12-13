using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;

namespace RunGym.Repositorios
{
    public class UsuariosRepository : IUsuarios
    {
        private readonly RunGymContext context;

        public UsuariosRepository(RunGymContext context)
        {
            this.context = context;
        }

        public async Task<List<Usuarios>> GetUsuarios()
        {
            var data = await context.usuarios.ToListAsync();
            return data;
        }
        public async Task<bool> PostUsuarios(Usuarios usuarios)
        {
            await context.usuarios.AddAsync(usuarios);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PutUsuarios(Usuarios usuarios)
        {
            context.usuarios.Update(usuarios);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUsuarios(int id)
        {
            var usuario = await context.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            context.usuarios.Remove(usuario);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
