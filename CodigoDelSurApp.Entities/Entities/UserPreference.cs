using System.ComponentModel.DataAnnotations;

namespace CodigoDelSurApp.Domain.Entities
{
    public class UserPreference
    {
        [Key]
        public required Guid UserId { get; set; }
        public required string PreferenceKey { get; set; }
        public required string PreferenceValue { get; set; }
    }
}
