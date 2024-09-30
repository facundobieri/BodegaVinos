using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetWines()
        {
            return Ok("Hola");
        }
    }
}