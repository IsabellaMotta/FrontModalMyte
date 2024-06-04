using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projeto.Myte.WebAPI.BackEnd.Models.Entities
{
    [Table("WBS")]
    public class Wbs
    {
        [Key]
        public int IdWbs { get; set; }

        [Required]
        public string? NomeWbs { get; set; }

        [Required]
        public string? CodigoWbs { get; set; }

        public string? Descricao { get; set; }

        // prop navegação

        [JsonIgnore]
        public ICollection<RegistroHoras>? RegistrosHoras { get; set; }
    }
}
