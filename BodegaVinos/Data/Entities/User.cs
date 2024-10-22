using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Nombre de usuario, requerido y único
        [Required]
        public string Username { get; set; } = string.Empty;

        // Contraseña, al menos 8 caracteres
        [MinLength(8)]
        public string Password { get; set; }
    }
}
