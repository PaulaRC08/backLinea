using BCProyecto.Domain.IRepository;
using BCProyecto.DTO;
using BCProyecto.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BCProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly IClase _clase;

        public ClaseController(IClase clase)
        {
            _clase = clase;
        }

        [HttpGet("{idClase}")]
        public async Task<IActionResult> GetClase(int idClase)
        {
            try
            {
                var clase = await _clase.getClase(idClase);
                if (clase == null)
                {
                    return Ok(new { message = "Clase no existe" });
                }
                return Ok(clase);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("sinMatricular/{idUsuario}")]
        [Authorize(Roles = ("True"))]
        [HttpGet]
        public async Task<IActionResult> GetClasesSinMatricular(int idUsuario)
        {
            try
            {
                var clase = await _clase.clasesSinMatricular(idUsuario);
                if (clase == null)
                {
                    return Ok(new { message = "Todas clases Matriculadas" });
                }
                return Ok(clase);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClases()
        {
            try
            {
                var clase = await _clase.getClases();
                if (clase == null)
                {
                    return Ok(new { message = "Sin Clases" });
                }
                return Ok(clase);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("listFiltro")]
        [Authorize(Roles = ("True"))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTOFiltroClase filtro)
        {
            try
            {
                var listaClases = await _clase.filtroListClases(filtro);
                if (listaClases == null)
                {
                    return Ok(new { message = "sinClases" });
                }
                else
                {
                    return Ok(listaClases);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("deleteClase/{idClase}")]
        [Authorize(Roles = ("True"))]
        [HttpGet]
        public async Task<IActionResult> deleteClase(int idClase)
        {
            try
            {
                await _clase.deleteClase(idClase);
                return Ok(new { message = "Usuario eliminado" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = ("True"))]
        public async Task<IActionResult> Post([FromBody] TbClase clase)
        {
            try
            {
                var validateClase = await _clase.validarClase(clase);
                if (validateClase)
                {
                    return Ok(new { message = "Clase ya Existe" });
                }
                await _clase.addClase(clase);
                return Ok(new { message = "Clase creada Exitosamente!" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = ("True"))]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateClase([FromRoute] int id, TbClase updateClase)
        {
            try
            {
                TbClase clase = await _clase.getClase(id);

                if (clase == null)
                {
                    return Ok(new { message = "No existe" });
                }

                clase.Nombreclase = updateClase.Nombreclase;
                clase.Descripcion = updateClase.Descripcion;
                clase.Creditos = updateClase.Creditos;
                clase.Codigo = updateClase.Codigo;


                await _clase.editarClase(clase);
                return Ok(new { message = "Editado" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
