using MyTe.Models;
using Projeto.Myte.WebAPI.BackEnd.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyTE.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; } 
        public string? Email { get; set; }
        public string? Senha { get; set; }

        public DateTime DataContratacao { get; set; }

        [ForeignKey("IdDepartamento")]
        [Required]
        public int IdDepartamento { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public int? IdTipoUsuario { get; set; }

        //props de navegação

        [JsonIgnore]
        public Departamento? Departamento { get; set; } // Pode ser nulo

        [JsonIgnore]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
