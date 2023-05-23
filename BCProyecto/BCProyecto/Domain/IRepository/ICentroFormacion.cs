using BCProyecto.Models;

namespace BCProyecto.Domain.IRepository
{
    public interface ICentroFormacion
    {
        Task<TbCentroFormacion> addCentro(TbCentroFormacion centro);
    }
}
