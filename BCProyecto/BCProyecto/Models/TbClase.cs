using System;
using System.Collections.Generic;

namespace BCProyecto.Models
{
    public partial class TbClase
    {
        public TbClase()
        {
            TbEstudianteclases = new HashSet<TbEstudianteclase>();
        }

        public int Idclase { get; set; }
        public string Nombreclase { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public int Creditos { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Temario { get; set; } = null!;
        public bool? Activo { get; set; }

        public virtual ICollection<TbEstudianteclase>? TbEstudianteclases { get; set; }
    }
}
