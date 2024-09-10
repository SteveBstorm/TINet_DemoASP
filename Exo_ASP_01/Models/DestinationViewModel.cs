namespace Exo_ASP_01.Models
{
    public class DestinationViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Country { get; set; }
    }
}
