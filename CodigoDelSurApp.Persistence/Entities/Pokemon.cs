namespace CodigoDelSurApp.Persistence.Entities
{
    public class Pokemon 
    {
        public int Id { get; set; } 
        public int Order { get; set; }
        public required string Name { get; set; }
        public string? Url { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}
