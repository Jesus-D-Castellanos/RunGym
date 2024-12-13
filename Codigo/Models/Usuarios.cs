using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RunGym.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get;  set; }
        public string Contrasena { get; set; }
        public char Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public Decimal Peso { get; set; }
        public Decimal Altura { get; set; }
        public Decimal HorasSueno { get; set; }
        public string ConsumoAgua { get; set; }
        public Decimal PesoDeseado { get; set; }
        public string TipoCuerpo { get; set; }
        public string CuerpoDeseado { get; set; }
        public string ResumenBienestar { get; set; }
    }
}