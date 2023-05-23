using BCProyecto.Models;

namespace BCProyecto.Domain.IRepository
{
    public interface IEstudianteClase
    {
        Task<bool> ValidateMatricula(TbEstudianteclase tbEstudianteclase);
        Task addMatricula(TbEstudianteclase tbEstudianteclase);
    }
}
