using BodegaVinos.Data.Entities;
using BodegaVinos.Models.DTO;
using BodegaVinos.Services.Implementations;
using BodegaVinos.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config; //Agregar using Microsoft.Extensions.Configuration;
        public AuthenticateController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsForAuthenticateDTO credentials)
        {
            User? userAuthenticated = _userService.Authenticate(credentials.Username, credentials.Password);
            if (userAuthenticated != null)
            {
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

                SigningCredentials signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                //Los claims son datos en clave->valor que nos permite guardar data del usuario.
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", userAuthenticated.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
                claimsForToken.Add(new Claim("given_name", userAuthenticated.Username)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app

                var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                  _config["Authentication:Issuer"],
                  _config["Authentication:Audience"],
                  claimsForToken,
                  DateTime.UtcNow,
                  DateTime.UtcNow.AddHours(1),
                  signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                return Ok(tokenToReturn);
            }
            return Unauthorized();
        }
    }
}
