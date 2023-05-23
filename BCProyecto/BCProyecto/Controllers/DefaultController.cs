using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET: api/<DefaultController>
        [HttpGet]
        public string Get()
        {
            return "Back-end Proyecto Corriendo Correctamente";
        }
    }
}
