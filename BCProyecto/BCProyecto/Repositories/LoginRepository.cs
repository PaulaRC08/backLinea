using BCProyecto.Domain.IRepository;
using BCProyecto.DTO;
using BCProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BCProyecto.Repositories
{
    public class LoginRepository: ILogin
    {
        private readonly BDCOLEGIOContext _context;

        public LoginRepository(BDCOLEGIOContext bdcolegioContext)
        {
            _context = bdcolegioContext;
        }

        public async Task saveHistory(TbHistoryLogin history)
        {
            var historyLogin = _context.Add(history);
            _context.SaveChanges();
        }

        public async Task<TbUsuario> validateUsuario(DTOLogin dTOlogin)
        {
            var user = await _context.TbUsuarios.Where(x => x.Usuario == dTOlogin.Usuario && x.Pass == dTOlogin.Pass).FirstOrDefaultAsync();
            return user;
        }
    }
}
