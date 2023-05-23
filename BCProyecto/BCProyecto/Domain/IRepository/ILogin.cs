using BCProyecto.DTO;
using BCProyecto.Models;

namespace BCProyecto.Domain.IRepository
{
    public interface ILogin
    {
        Task <TbUsuario> validateUsuario(DTOLogin dTOlogin);
        Task saveHistory(TbHistoryLogin history);
    }
}
