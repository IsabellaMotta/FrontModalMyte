using MyTE.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projeto.Myte.WebAPI.BackEnd.Models.Entities
{
    [Table("TipoUsuario")]

    public class TipoUsuario
    {
        [Key]
        public int IdTipoUsuario { get; set; }
        public string? NomeTipoUsuario { get; set; }

        [JsonIgnore]
        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
