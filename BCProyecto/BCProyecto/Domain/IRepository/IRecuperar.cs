using BCProyecto.DTO;
using BCProyecto.Models;

namespace BCProyecto.Domain.IRepository
{
    public interface IRecuperar
    {
        Task<TbUsuario> validateUsuario(string usuario);

        Task saveToken(TbUsuario usuario, string Token);

        Task<TbUsuario> ValidarToken(DTOToken token);
        Task UpdatePassword(TbUsuario usuario);
    }
}
