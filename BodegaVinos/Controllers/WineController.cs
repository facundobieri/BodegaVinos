using BodegaVinos.Data.Entities;
using BodegaVinos.Data.Repository;
using BodegaVinos.Models.DTO;
using BodegaVinos.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        private readonly WineService _wineService;
        public WineController(WineService wineService)
        {
            _wineService = wineService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_wineService.GetWines());
        }
        [HttpPost]
        public IActionResult NewWine(CreateWineDTO createWineDTO)
        {
            _wineService.CreateWine(createWineDTO);
            return Ok();
        }

        [HttpPut("{id}/AddStock")]
        public IActionResult AddStock(int id, [FromBody] int stock)
        {
            _wineService.AddStockById(id, stock);
            return Ok();
        }

        [HttpPut("{id}/RemoveStock")]
        public IActionResult RemoveStock(int id, [FromBody] int stock)
        {
            _wineService.RemoveStockById(id, stock);
            return Ok();
        }




    }
}