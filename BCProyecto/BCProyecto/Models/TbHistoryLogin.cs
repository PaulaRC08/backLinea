namespace BCProyecto.Models
{
    public class TbHistoryLogin
    {
        public int IdLogin { get; set; }
        public int Idusuario { get; set; }
        public string Usuario { get; set; } = null!;
        public string IPEquipo { get; set; } = null!;
        public string NombreEquipo { get; set; } = null!;
        public DateTime? Fecha { get; set; }

    }
}
