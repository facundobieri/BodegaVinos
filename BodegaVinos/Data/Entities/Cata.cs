using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodegaVinos.Data.Entities
{
    public class Cata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [ForeignKey("WineId")]
        public int WineId { get; set; }
        public Wine Wine { get; set; }
        public DateTime DateTime { get; set; }
        public List<Guest> Guests { get; set; }
    }
}
