using BodegaVinos.Models.DTO;
using BodegaVinos.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService) {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO loginData)
        {
            if (_userService.validateUser(loginData))
            {
                return Ok("Login Successful");
            }
            return Unauthorized("Invalid username or password");
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] CreateUserDTO createUserDTO)
        {
            _userService.CreateUser(createUserDTO);
            return Ok("User created successfully");
        }
    }
}
