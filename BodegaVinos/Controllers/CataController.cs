using BodegaVinos.Models.DTO;
using BodegaVinos.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CataController : ControllerBase
    {
        private readonly ICataService _cataService;

        public CataController(ICataService cataService)
        {
            _cataService = cataService;
        }

        [HttpPost]
        public IActionResult CreateCata([FromBody] CreateCataDTO cata)
        {
            _cataService.CreateCata(cata);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCatasByDate()
        {
            return Ok(_cataService.GetCatasByDate());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGuests(int id, [FromBody] UpdateGuestsDTO guests)
        {
            _cataService.UpdateGuests(id, guests);
            return Ok();
        }
    }
}
