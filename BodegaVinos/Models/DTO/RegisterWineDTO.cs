using System.ComponentModel.DataAnnotations;

namespace BodegaVinos.Models.DTO
{
    public class RegisterWineDTO
    {
        [Required]
        public string Name { get; set; }
        public string Variety { get; set; }
        [Required]
        public int Year { get; set; }
        public string Region { get; set; }
        public int Stock { get; set; }
    }
}
