using System.ComponentModel.DataAnnotations.Schema;

namespace CodigoDelSurApp.Domain.Entities
{
    public class Beer 
    {
        public int Id { get; set; } 
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Image { get; set; }
        public double Abv { get; set; }
        public double Ibu { get; set; }
        [Column("first_brewed")]
        public double FirstBrewed { get; set; }
    }

}
