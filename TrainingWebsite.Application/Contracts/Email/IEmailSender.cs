using TrainingWebsite.Application.Models.Email;

namespace TrainingWebsite.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(EmailMessage emailMessage);
    
}