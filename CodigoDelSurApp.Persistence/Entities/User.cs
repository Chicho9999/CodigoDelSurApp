using System.Text.Json.Serialization;

namespace CodigoDelSurApp.Persistence.Entities
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Username { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }
    }
}
