using BCProyecto.Domain.IRepository;
using BCProyecto.DTO;
using BCProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BCProyecto.Repositories
{
    public class RecuperarRepository: IRecuperar
    {

        private readonly BDCOLEGIOContext _context;

        public RecuperarRepository(BDCOLEGIOContext bdcolegioContext)
        {
            _context = bdcolegioContext;
        }

        public async Task saveToken(TbUsuario usuario, string Token)
        {
            usuario.TokenCamPass = Token;
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePassword(TbUsuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<TbUsuario> ValidarToken(DTOToken token)
        {
            var usuario = await _context.TbUsuarios.Where(x => x.TokenCamPass == token.token).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<TbUsuario> validateUsuario(string usuario)
        {
            var user = await _context.TbUsuarios.Where(x => x.Usuario == usuario).FirstOrDefaultAsync();
            return user;
        }


    }
}
