using System.Text.Json.Serialization;
using CodigoDelSurApp.Domain.Common;

namespace CodigoDelSurApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }
    }
}
