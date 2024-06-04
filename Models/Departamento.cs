using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTE.Models
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }

        public string? NomeDepartamento { get; set; }

        // Propriedade de navegação para Usuarios
        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
