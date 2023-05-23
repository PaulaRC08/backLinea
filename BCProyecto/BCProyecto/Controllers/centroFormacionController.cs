using BCProyecto.Domain.IRepository;
using BCProyecto.Models;
using BCProyecto.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BCProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class centroFormacionController : ControllerBase
    {
        private readonly ICentroFormacion _centroFormacion;

        public centroFormacionController(ICentroFormacion centroFormacion)
        {
            _centroFormacion = centroFormacion;
        }

        [HttpPost]
        [Authorize(Roles = ("True"))]
        public async Task<IActionResult> PostAdd([FromBody] TbCentroFormacion centroFormacion)
        {
            try
            {
                var centroRegistrado = await _centroFormacion.addCentro(centroFormacion);
                return Ok(centroRegistrado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
