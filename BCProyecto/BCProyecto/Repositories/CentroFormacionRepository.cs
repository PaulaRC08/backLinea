using BCProyecto.Domain.IRepository;
using BCProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BCProyecto.Repositories
{
    public class CentroFormacionRepository : ICentroFormacion
    {
        private readonly BDCOLEGIOContext _context;

        public CentroFormacionRepository(BDCOLEGIOContext bdcolegioContext)
        {
            _context = bdcolegioContext;
        }

        public async Task<TbCentroFormacion> addCentro(TbCentroFormacion centro)
        {
            _context.Add(centro);
            await _context.SaveChangesAsync();
            var centroRegistrado = _context.TbCentroFormacion.Where(x => x.Nombrecentro == centro.Nombrecentro).FirstOrDefault();
            return centroRegistrado;
        }
    }
}
