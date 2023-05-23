using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BCProyecto.Models
{
    public partial class TbEstudiante
    {
        public TbEstudiante()
        {
            TbEstudianteclases = new HashSet<TbEstudianteclase>();
        }
        [Key]
        public int Idestudiante { get; set; }
        public string? Nombre { get; set; } = null!;
        public string? Apellido { get; set; } = null!;
        public string? Codigoestudiante { get; set; } = null!;
        public string? Numeroidentificacion { get; set; } = null!;
        public int? Idusuario { get; set; }
        public bool? Activo { get; set; }

        public virtual TbUsuario? IdusuarioNavigation { get; set; } = null!;
        public virtual ICollection<TbEstudianteclase>? TbEstudianteclases { get; set; }
    }
}
