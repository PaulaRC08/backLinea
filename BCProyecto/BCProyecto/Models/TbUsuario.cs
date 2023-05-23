using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BCProyecto.Models
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbEstudiantes = new HashSet<TbEstudiante>();
        }
        [Key]
        public int Idusuario { get; set; }
        public string? Usuario { get; set; } = null!;
        public string? Pass { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public bool? Administrador { get; set; }
        public string? TokenCamPass { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<TbEstudiante>? TbEstudiantes { get; set; }
    }
}
