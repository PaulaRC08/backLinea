using System;
using System.Collections.Generic;

namespace BCProyecto.Models
{
    public partial class TbEstudianteclase
    {
        public int Idestudianteclases { get; set; }
        public int Idclase { get; set; }
        public int Idestudiante { get; set; }

        public virtual TbClase? IdclaseNavigation { get; set; } = null!;
        public virtual TbEstudiante? IdestudianteNavigation { get; set; } = null!;
    }
}
