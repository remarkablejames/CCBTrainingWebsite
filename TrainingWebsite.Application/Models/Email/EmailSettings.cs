namespace TrainingWebsite.Application.Models.Email;

public class EmailSettings
{
    public required String ApiKey { get; set; } 
    public required String FromName { get; set; }
    public required string FromAddress { get; set; }
    
}