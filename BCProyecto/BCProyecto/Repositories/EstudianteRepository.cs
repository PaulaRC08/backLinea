using BCProyecto.Domain.IRepository;
using BCProyecto.DTO;
using BCProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BCProyecto.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        private readonly BDCOLEGIOContext _context;

        public EstudianteRepository(BDCOLEGIOContext bdcolegioContext)
        {
            _context = bdcolegioContext;
        }

        public async Task<TbEstudiante> addEstudiante(TbEstudiante estudiante)
        {
            _context.Add(estudiante);
            await _context.SaveChangesAsync();
            var usuarioRegistrado = _context.TbEstudiantes.Where(x => x.IdusuarioNavigation.Usuario == estudiante.IdusuarioNavigation.Usuario).FirstOrDefault();
            return usuarioRegistrado;
        }

        public async Task deleteEstudiante(int idEstudiante)
        {
            var estudiante = await _context.TbEstudiantes.Where(x => x.Idestudiante == idEstudiante)
                                        .Include(x => x.IdusuarioNavigation)
                                        .FirstOrDefaultAsync();
            estudiante.Activo = false;
            estudiante.IdusuarioNavigation.Activo = false;
            _context.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task editarEstudiante(TbEstudiante estudiante)
        {
            _context.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TbEstudiante>> filtroListEstudiantes(DTOFiltro filtro)
        {
            var list = await _context.TbEstudiantes
                            .Where(x => ((filtro.identificacion == "") || (x.Numeroidentificacion == filtro.identificacion)) &&
                                    ((filtro.nombre == "") || EF.Functions.Like(x.Nombre, ($"%{filtro.nombre}%"))) &&
                                    ((filtro.apellido == "") || EF.Functions.Like(x.Apellido, ($"%{filtro.apellido}%")))
                                    && x.Activo == true)
                            .Include(x => x.TbEstudianteclases)
                            .OrderBy(x => x.Nombre).Take(10)
                            .ToListAsync();
            return list;
        }

        public async Task<TbEstudiante> getEstudiante(int idEstudiante)
        {
            /*var estudiante = await _context.TbEstudiantes.Where(x => x.Idestudiante == idEstudiante)
                                                    .Include(x => x.TbEstudianteclases)
                                                        .ThenInclude(x => x.IdclaseNavigation)
                                                    .FirstOrDefaultAsync();*/
            var estudiante = await _context.TbEstudiantes.Where(x => x.Idestudiante == idEstudiante && x.Activo == true)
                                                    .Include(x => x.IdusuarioNavigation)
                                                    .Include(x => x.TbEstudianteclases)
                                                        .ThenInclude(x => x.IdclaseNavigation)
                                                    .FirstOrDefaultAsync();
            return estudiante;
        }

        public async Task<TbEstudiante> getEstudianteClases(int idEstudiante)
        {
            var estudiante = await _context.TbEstudiantes.Where(x => x.Idestudiante == idEstudiante && x.Activo == true)
                            .Include(x => x.TbEstudianteclases)
                                .ThenInclude(x => x.IdclaseNavigation)
                            .FirstOrDefaultAsync();
            return estudiante;
        }

        public async Task<TbEstudiante> getEstudianteUser(int idUsuario)
        {
            var estudiante = await _context.TbEstudiantes.Where(x => x.Idusuario == idUsuario && x.Activo == true)
                                        .Include(x => x.TbEstudianteclases)
                                            .ThenInclude(x => x.IdclaseNavigation)
                                        .FirstOrDefaultAsync();
            return estudiante;
        }

        public async Task<List<TbEstudiante>> listEstudiantes()
        {
            var list = await _context.TbEstudiantes
                                        .Where(x=>x.Activo == true)
                                        .Include(x=>x.TbEstudianteclases)
                                        .OrderBy(x => x.Apellido)
                                        .ToListAsync();
            return list;
        }

        public async Task<bool> ValidateExistence(TbEstudiante usuario)
        {
            var validateExistence = await _context.TbUsuarios.AnyAsync(x => x.Usuario == usuario.IdusuarioNavigation.Usuario && x.Activo == true);
            return validateExistence;
        }
    }
}
