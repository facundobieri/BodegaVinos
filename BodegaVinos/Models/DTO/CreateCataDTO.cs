namespace BodegaVinos.Models.DTO
{
    public class CreateCataDTO
    {
        public string Name { get; set; }
        public int WineId { get; set; }
        public DateTime DateTime { get; set; }
        public List<CreateGuestDTO> Guests { get; set; }
    }
}
