using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exo_ASP_01.Models
{
    public class ContactFormModel
    {
        [EmailAddress]
        [DisplayName("Adresse courriel")]
        public required string Email { get; set; }
        [MinLength(3)]
        [MaxLength(15)]
        public string? Pseudo { get; set; }

        public required string Message { get; set; }
        [Range(18, 69, ErrorMessage = "Pas d'enfant, pas d'ancêtre")]
        public int Age { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [DisplayName("Mot de passe")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Les deux champs mots de passe doivent correspondre")]
        public string ConfirmPassword { get; set; }

    }
}
