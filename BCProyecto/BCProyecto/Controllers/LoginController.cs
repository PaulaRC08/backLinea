using BCProyecto.Domain.IRepository;
using BCProyecto.DTO;
using BCProyecto.Models;
using BCProyecto.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace BCProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        private readonly IConfiguration _config;
        public LoginController(ILogin login, IConfiguration config)
        {
            _login = login;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTOLogin login) 
        {
            try
            {
                login.Pass = Encriptar.EncriptarPassword(login.Pass);
                var user = await _login.validateUsuario(login);
                if (user == null)
                {
                    return Ok(new { message = "Datos incorrectos" });
                }

                var hostName = Dns.GetHostName();
                IPAddress[] addresses = Dns.GetHostAddresses(hostName);
                StringBuilder sb = new StringBuilder();
                string ipAddresses;

                foreach (IPAddress address in addresses)
                    sb.Append($"{address}, ");

                ipAddresses = sb.ToString().TrimEnd(", ".ToCharArray());

                TbHistoryLogin history = new TbHistoryLogin();
                history.Usuario = user.Usuario;
                history.Idusuario = user.Idusuario;
                history.IPEquipo = ipAddresses;
                history.NombreEquipo = hostName;
                history.Fecha = DateTime.Now;
                //await _login.saveHistory(history);
                string tokenString = JwtConfigurator.GetToken(user, _config);
                return Ok(new { message = new { token = tokenString } });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

    }
}
