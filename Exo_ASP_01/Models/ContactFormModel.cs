using System.ComponentModel.DataAnnotations;

namespace Exo_ASP_01.Models
{
    public class ContactFormModel
    {
        [EmailAddress]
        public required string Email { get; set; }

        public string? Pseudo { get; set; }

        public required string Message { get; set; }
    }
}
