using Microsoft.AspNetCore.Identity;

namespace TrainingWebsite.Identity.Models;

public class ApplicationUser: IdentityUser
{
    public string FirstName { get; set; } =  String.Empty;
    public string LastName { get; set; } =  String.Empty;
    
}