namespace CodigoDelSurApp.Domain.Entities
{
    public class PotterBook 
    {
        public int Number { get; set; } 
        public int Order { get; set; }
        public required string Title { get; set; }
        public required string OriginalTitle { get; set; }
        public required string ReleaseDate { get; set; }
        public required string Description { get; set; }
        public int Pages { get; set; }
        public string? Cover { get; set; }
    }

}
