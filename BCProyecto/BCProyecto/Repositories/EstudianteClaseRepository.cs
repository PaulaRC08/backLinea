using BCProyecto.Domain.IRepository;
using BCProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BCProyecto.Repositories
{
    public class EstudianteClaseRepository : IEstudianteClase
    {
        private readonly BDCOLEGIOContext _context;

        public EstudianteClaseRepository(BDCOLEGIOContext bdcolegioContext)
        {
            _context = bdcolegioContext;
        }

        public async Task<bool> ValidateMatricula(TbEstudianteclase tbEstudianteclase)
        {
            var validateExistence = await _context.TbEstudianteclases.AnyAsync(x => x.Idclase == tbEstudianteclase.Idclase && x.Idestudiante == tbEstudianteclase.Idestudiante);
            return validateExistence;
        }

        public async Task addMatricula(TbEstudianteclase tbEstudianteclase)
        {
            _context.Add(tbEstudianteclase);
            await _context.SaveChangesAsync();
        }

    }
}
