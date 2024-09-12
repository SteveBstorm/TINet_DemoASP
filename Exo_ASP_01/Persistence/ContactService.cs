using Exo_ASP_01.Models;

namespace Exo_ASP_01.Persistence
{
    public static class ContactService
    {
        public static List<ContactFormModel> Contacts { get; set; } = new List<ContactFormModel>() 
        { 
            new ContactFormModel
            {
                Email = "arthur@kaamelott.com",
                Pseudo = "Le sanglier de cornouail",
                Age = 42,
                Message = "J'vous soupçonne d'être un gros nul",
                Password = "Test1234"
                }
        };


    }
}
