using MyTE.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projeto.Myte.WebAPI.BackEnd.Models.Entities
{
    [Table("RegistroHoras")]
    public class RegistroHoras
    {
        [Key]
        public int IdRegistroHoras { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [Required]
        public DateTime DataRegistro { get; set; }

        [Required]
        public int IdWBS { get; set; }

        [ForeignKey("IdWBS")]
        [JsonIgnore]
        public Wbs? Wbs { get; set; }

        [Required]
        public decimal HorasTrabalhadas { get; set; }
    }
}
