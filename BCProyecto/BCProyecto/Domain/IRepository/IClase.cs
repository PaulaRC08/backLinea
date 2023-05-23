using BCProyecto.DTO;
using BCProyecto.Models;

namespace BCProyecto.Domain.IRepository
{
    public interface IClase
    {
        Task<List<TbClase>> filtroListClases(DTOFiltroClase filtro);
        Task deleteClase(int idClase);
        Task editarClase(TbClase clase);
        Task<List<TbClase>> getClases();
        Task<TbClase> getClase(int idClase);
        Task addClase(TbClase clase);
        Task<bool> validarClase(TbClase clase);
        Task<List<TbClase>> clasesSinMatricular(int idEstudiante);

    }
}
