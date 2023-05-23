using BCProyecto.Domain.IRepository;
using BCProyecto.DTO;
using BCProyecto.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BCProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperarController : ControllerBase
    {
        private readonly IRecuperar _recuperar;

        public RecuperarController (IRecuperar recuperar)
        {
            _recuperar = recuperar;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTORecuperar dTORecuperar)
        {
            try
            {
                var usuario = await _recuperar.validateUsuario(dTORecuperar.Usuario);
                if (usuario == null)
                {
                    return Ok(new { message = "No existe" });
                }

                //Crear token y guardarlo
                string token = Encriptar.EncriptarToken(Guid.NewGuid().ToString());
                await _recuperar.saveToken(usuario, token);
                Correo.EnviarCorreo(usuario, token);
                return Ok(new { message = token });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [Route("CambiarPassword")]
        [HttpPut]
        public async Task<IActionResult> CambiarContraseña([FromBody] DTOToken dtoToken)
        {
            try
            {
                //string passwordEncriptado = Encriptar.EncriptarPassword(cambiarPassword.passwordAnterior);
                var usuario = await _recuperar.ValidarToken(dtoToken);
                if (usuario == null)
                {
                    return Ok(new { message = "Token Incorrecto" });
                }
                else
                {
                    usuario.Pass = Encriptar.EncriptarPassword(dtoToken.password);
                    usuario.TokenCamPass = null;
                    await _recuperar.UpdatePassword(usuario);
                    return Ok(new { message = "La password fue actualizada con exito!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }

}
