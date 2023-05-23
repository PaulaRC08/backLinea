using BCProyecto.Domain.IRepository;
using BCProyecto.DTO;
using BCProyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BCProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteClaseController : ControllerBase
    {
        private readonly IEstudianteClase _estudianteclase;

        public EstudianteClaseController(IEstudianteClase estudianteclase)
        {
            _estudianteclase = estudianteclase;
        }

        [HttpPost]
        [Authorize(Roles = ("True"))]
        public async Task<IActionResult> Post([FromBody] TbEstudianteclase estudianteclase)
        {
            try
            {
                var listaEstudiantes = await _estudianteclase.ValidateMatricula(estudianteclase);
                if (listaEstudiantes)
                {
                    return Ok(new { message = "Clase ya Matriculada" });
                }
                await _estudianteclase.addMatricula(estudianteclase);
                return Ok(new { message = "Clase Matriculada Exitosamente!" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
