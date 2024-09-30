using BodegaVinos.Data.Entities;
using BodegaVinos.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            WineRepository wineRepository = new WineRepository();
            List<Wine> wines = wineRepository.Wines;
            return Ok(wines);
        }
    }
}