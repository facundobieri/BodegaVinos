using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Models.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
