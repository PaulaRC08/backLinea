using BCProyecto.Domain.IRepository;
using BCProyecto.DTO;
using BCProyecto.Models;
using BCProyecto.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BCProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiante _estudiante;

        public EstudiantesController(IEstudiante estudiante)
        {
            _estudiante = estudiante;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstudiantes()
        {
            try
            {
                var listaEstudiantes = await _estudiante.listEstudiantes();
                if (listaEstudiantes == null)
                {
                    return Ok(new { message = "sinEstudiantes" });
                }
                else
                {
                    return Ok(listaEstudiantes);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{idEstudiante}")]
        public async Task<IActionResult> GetEstudiante(int idEstudiante)
        {
            try
            {
                var estudiante = await _estudiante.getEstudiante(idEstudiante);
                if (estudiante == null)
                {
                    return Ok(new { message = "Estudiante no existe" });
                }
                return Ok(estudiante);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("estudianteUser/{idUsuario}")]
        [HttpGet]
        public async Task<IActionResult> GetEstudianteUser(int idUsuario)
        {
            try
            {
                var estudiante = await _estudiante.getEstudianteUser(idUsuario);
                if (estudiante == null)
                {
                    return Ok(new { message = "Estudiante no existe" });
                }
                return Ok(estudiante);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("deleteEstudiante/{idEstudiante}")]
        [Authorize(Roles = ("True"))]
        [HttpGet]
        public async Task<IActionResult> deleteEstudiante(int idEstudiante)
        {
            try
            {
                await _estudiante.deleteEstudiante(idEstudiante);
                return Ok(new { message = "Usuario eliminado" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("estudianteClases/{idEstudiante}")]
        [HttpGet]
        public async Task<IActionResult> GetEstudianteClases(int idEstudiante)
        {
            try
            {
                var estudiante = await _estudiante.getEstudianteClases(idEstudiante);
                if (estudiante == null)
                {
                    return Ok(new { message = "Estudiante no existe" });
                }
                return Ok(estudiante);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = ("True"))]
        public async Task<IActionResult> Post([FromBody] DTOFiltro filtro)
        {
            try
            {
                var listaEstudiantes = await _estudiante.filtroListEstudiantes(filtro);
                if (listaEstudiantes == null)
                {
                    return Ok(new { message = "sinEstudiantes" });
                }
                else
                {
                    return Ok(listaEstudiantes);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("add")]
        [Authorize(Roles =("True"))]
        [HttpPost]
        public async Task<IActionResult> PostAdd([FromBody] TbEstudiante estudiante)
        {
            try
            {

                estudiante.IdusuarioNavigation.FechaCreacion = DateTime.Now;
                var validateExistence = await _estudiante.ValidateExistence(estudiante);
                if (validateExistence)
                {
                    return Ok(new { message = "Usuario ya existe" });
                }
                estudiante.IdusuarioNavigation.Pass = Encriptar.EncriptarPassword(estudiante.IdusuarioNavigation.Pass);
                estudiante.Activo = true;
                estudiante.IdusuarioNavigation.Activo = true;
                var usuarioRegistrado = await _estudiante.addEstudiante(estudiante);
                return Ok(usuarioRegistrado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*[Route("editar")]
        [HttpPut]
        public async Task<IActionResult> CambiarContraseña([FromBody] TbEstudiante estudiante)
        {
            try
            {
                await _estudiante.editarEstudiante(estudiante);
                return Ok(new { message = "Estudiante editado" });
                
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }*/


        [HttpPut]
        [Authorize(Roles = ("True"))]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEstudiante([FromRoute]  int id, TbEstudiante updateEstudiante)
        {
            try
            {
                TbEstudiante estudiante = await _estudiante.getEstudiante(id);

                if(estudiante == null)
                {
                    return Ok(new { message = "No existe" });
                }

                estudiante.Nombre = updateEstudiante.Nombre;
                estudiante.Apellido = updateEstudiante.Apellido;
                estudiante.Codigoestudiante = updateEstudiante.Codigoestudiante;
                estudiante.Numeroidentificacion = updateEstudiante.Numeroidentificacion;
                estudiante.IdusuarioNavigation.Usuario = updateEstudiante.IdusuarioNavigation.Usuario;
                estudiante.IdusuarioNavigation.Email = updateEstudiante.IdusuarioNavigation.Email;

                await _estudiante.editarEstudiante(estudiante);
                return Ok(new { message = "Editado" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
