using Microsoft.EntityFrameworkCore;
using RunGym.Models;

namespace RunGym.Repositorios
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<RutinasEjercicio> rutinasEjercicio { get; set; }
        public DbSet<Metas> metas { get; set; }
        public DbSet<Ejercicios> ejercicios { get; set; }
        public DbSet<Dieta> dieta { get; set; }
        public DbSet<Comidas> comidas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);
        }

        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");
            modelBuilder.Entity<Usuarios>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuarios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Usuarios>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Usuarios>().Property(u => u.Apellido).HasColumnName("Apellido");
            modelBuilder.Entity<Usuarios>().Property(u => u.Contrasena).HasColumnName("Contrasena");
            modelBuilder.Entity<Usuarios>().Property(u => u.Genero).HasColumnName("Genero");
            modelBuilder.Entity<Usuarios>().Property(u => u.FechaNacimiento).HasColumnName("FechaNacimiento");
            modelBuilder.Entity<Usuarios>().Property(u => u.Email).HasColumnName("Email");
            modelBuilder.Entity<Usuarios>().Property(u => u.Peso).HasColumnName("Peso");
            modelBuilder.Entity<Usuarios>().Property(u => u.Altura).HasColumnName("Altura");
            modelBuilder.Entity<Usuarios>().Property(u => u.HorasSueno).HasColumnName("HorasSueno");
            modelBuilder.Entity<Usuarios>().Property(u => u.ConsumoAgua).HasColumnName("ConsumoAgua");
            modelBuilder.Entity<Usuarios>().Property(u => u.PesoDeseado).HasColumnName("PesoDeseado");
            modelBuilder.Entity<Usuarios>().Property(u => u.TipoCuerpo).HasColumnName("TipoCuerpo");
            modelBuilder.Entity<Usuarios>().Property(u => u.CuerpoDeseado).HasColumnName("CuerpoDeseado");
            modelBuilder.Entity<Usuarios>().Property(u => u.ResumenBienestar).HasColumnName("ResumenBienestar");

            modelBuilder.Entity<RutinasEjercicio>().ToTable("RutinasEjercicio");
            modelBuilder.Entity<RutinasEjercicio>().HasKey(u => u.Id);
            modelBuilder.Entity<RutinasEjercicio>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<RutinasEjercicio>().Property(u => u.IdUsuario).HasColumnName("IdUsuario");
            modelBuilder.Entity<RutinasEjercicio>().Property(u => u.NombreRutina).HasColumnName("NombreRutina");
            modelBuilder.Entity<RutinasEjercicio>().Property(u => u.FechaInicio).HasColumnName("FechaInicio");
            modelBuilder.Entity<RutinasEjercicio>().Property(u => u.FechaFin).HasColumnName("FechaFin");

            modelBuilder.Entity<Metas>().ToTable("Metas");
            modelBuilder.Entity<Metas>().HasKey(u => u.Id);
            modelBuilder.Entity<Metas>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Metas>().Property(u => u.IdUsuario).HasColumnName("IdUsuario");
            modelBuilder.Entity<Metas>().Property(u => u.MetaPrincipal).HasColumnName("MetaPrincipal");
            modelBuilder.Entity<Metas>().Property(u => u.CuerpoActual).HasColumnName("CuerpoActual");
            modelBuilder.Entity<Metas>().Property(u => u.CuerpoDeseado).HasColumnName("CuerpoDeseado");
            modelBuilder.Entity<Metas>().Property(u => u.Ultimavez_CuerpoIdeal).HasColumnName("Ultimavez_CuerpoIdeal");
            modelBuilder.Entity<Metas>().Property(u => u.FechaInicio).HasColumnName("FechaInicio");
            modelBuilder.Entity<Metas>().Property(u => u.FechaFin).HasColumnName("FechaFin");
            modelBuilder.Entity<Metas>().Property(u => u.Progreso).HasColumnName("Progreso");

            modelBuilder.Entity<Ejercicios>().ToTable("Ejercicios");
            modelBuilder.Entity<Ejercicios>().HasKey(u => u.Id);
            modelBuilder.Entity<Ejercicios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Ejercicios>().Property(u => u.IdRutina).HasColumnName("IdRutina");
            modelBuilder.Entity<Ejercicios>().Property(u => u.Nombre_Ejercicio).HasColumnName("Nombre_Ejercicio");
            modelBuilder.Entity<Ejercicios>().Property(u => u.Descripcion).HasColumnName("Descripcion");

            modelBuilder.Entity<Dieta>().ToTable("Dieta");
            modelBuilder.Entity<Dieta>().HasKey(u => u.Id);
            modelBuilder.Entity<Dieta>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Dieta>().Property(u => u.IdUsuario).HasColumnName("IdUsuario");
            modelBuilder.Entity<Dieta>().Property(u => u.TipoDieta).HasColumnName("TipoDieta");
            modelBuilder.Entity<Dieta>().Property(u => u.FechaInicio).HasColumnName("FechaInicio");
            modelBuilder.Entity<Dieta>().Property(u => u.FechaFin).HasColumnName("FechaFin");
            modelBuilder.Entity<Dieta>().Property(u => u.CaloriasDiarias).HasColumnName("CaloriasDiarias");
            modelBuilder.Entity<Dieta>().Property(u => u.Micronutrientes).HasColumnName("Macronutrientes");
            modelBuilder.Entity<Dieta>().Property(u => u.Descripcion).HasColumnName("Descripcion");

            modelBuilder.Entity<Comidas>().ToTable("Comidas");
            modelBuilder.Entity<Comidas>().HasKey(u => u.Id);
            modelBuilder.Entity<Comidas>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Comidas>().Property(u => u.IdDieta).HasColumnName("IdDieta");
            modelBuilder.Entity<Comidas>().Property(u => u.TipoComida).HasColumnName("TipoComida");
            modelBuilder.Entity<Comidas>().Property(u => u.HoraComida).HasColumnName("HoraComida");
            modelBuilder.Entity<Comidas>().Property(u => u.Descripcion).HasColumnName("Descripcion");
        }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
