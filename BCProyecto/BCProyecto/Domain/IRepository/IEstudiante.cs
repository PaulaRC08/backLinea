using BCProyecto.DTO;
using BCProyecto.Models;

namespace BCProyecto.Domain.IRepository
{
    public interface IEstudiante
    {
        Task<bool> ValidateExistence(TbEstudiante usuario);
        Task<TbEstudiante> addEstudiante(TbEstudiante estudiante);
        Task deleteEstudiante(int idEstudiante);
        Task editarEstudiante(TbEstudiante estudiante);
        Task<TbEstudiante> getEstudiante(int idEstudiante);
        Task<TbEstudiante> getEstudianteClases(int idEstudiante);
        Task<TbEstudiante> getEstudianteUser(int idUsuario);
        Task <List<TbEstudiante>> listEstudiantes();
        Task<List<TbEstudiante>> filtroListEstudiantes(DTOFiltro filtro);
    }
}
