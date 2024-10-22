namespace BodegaVinos.Data.Entities
{
    public class Cata
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Wine { get; set; }
        public DateTime DateTime { get; set; }
        public List<Guess> Guesses { get; set; }
    }
}
