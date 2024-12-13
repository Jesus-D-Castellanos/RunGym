using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RunGym.Models
{
    public class Metas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string MetaPrincipal { get; set; }
        public string CuerpoActual { get; set; }
        public string CuerpoDeseado { get; set; }
        public DateTime Ultimavez_CuerpoIdeal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Progreso { get; set; }

    }
}