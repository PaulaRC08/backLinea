using BCProyecto.Domain.IRepository;
using BCProyecto.DTO;
using BCProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BCProyecto.Repositories
{
    public class ClaseRepository : IClase
    {

        private readonly BDCOLEGIOContext _context;

        public ClaseRepository(BDCOLEGIOContext bdcolegioContext)
        {
            _context = bdcolegioContext;
        }

        public async Task addClase(TbClase clase)
        {
            clase.Activo = true;
            _context.Add(clase);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TbClase>> clasesSinMatricular(int idEstudiante)
        {
            var clasesSinRelacion = await _context.TbClases
                        .Where(c => !_context.TbEstudianteclases
                            .Any(ec => ec.Idclase == c.Idclase && ec.Idestudiante == idEstudiante) && c.Activo == true)
                        .ToListAsync();
            return clasesSinRelacion;
        }

        public async Task deleteClase(int idClase)
        {
            var clase = await _context.TbClases.Where(x => x.Idclase == idClase)
                            .FirstOrDefaultAsync();
            clase.Activo = false;
            _context.Update(clase);
            await _context.SaveChangesAsync();
        }

        public async Task editarClase(TbClase clase)
        {
            _context.Update(clase);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TbClase>> filtroListClases(DTOFiltroClase filtro)
        {
            var list = await _context.TbClases
                .Where(x => 
                        ((filtro.nombre == "") || EF.Functions.Like(x.Nombreclase, ($"%{filtro.nombre}%"))) &&
                        ((filtro.codigo == "") || EF.Functions.Like(x.Codigo, ($"%{filtro.codigo}%")))
                        && x.Activo == true)
                .OrderBy(x => x.Nombreclase).Take(10)
                .ToListAsync();
            return list;
        }

        public async Task<TbClase> getClase(int idClase)
        {
            var clase = await _context.TbClases.Where(x => x.Idclase == idClase && x.Activo == true)
                .Include(x => x.TbEstudianteclases)
                    .ThenInclude(x => x.IdestudianteNavigation)
                .FirstOrDefaultAsync();
            return clase;
        }

        public async Task<List<TbClase>> getClases()
        {
            var clase = await _context.TbClases.Where(x => x.Activo == true)
                .ToListAsync();
            return clase;
        }

        public async Task<bool> validarClase(TbClase clase)
        {
            var validateExistence = await _context.TbClases.AnyAsync(x => x.Codigo == clase.Codigo && x.Activo == true);
            return validateExistence;
        }
    }
}
