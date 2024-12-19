using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CodigoDelSurApp.Domain.Common;

namespace CodigoDelSurApp.Domain.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(50)]
        public required string FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(50)]
        public required string Username { get; set; }
        [MaxLength(50)]
        [EmailAddress]
        public required string Email { get; set; }

        [JsonIgnore]
        [MaxLength(200)]
        public string? Password { get; set; }
    }
}
