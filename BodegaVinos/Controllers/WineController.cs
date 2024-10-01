using BodegaVinos.Data.Entities;
using BodegaVinos.Data.Repository;
using BodegaVinos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        private readonly WineService _wineService;
        public WineController(WineService wineService) {
            _wineService = wineService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_wineService.GetWines());
        }
    }
}