using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using TrainingWebsite.Application.Contracts.Email;
using TrainingWebsite.Application.Models.Email;

namespace TrainingWebsite.Infrastructure.EmailService;

public class EmailSender: IEmailSender
{
    private readonly IOptions<EmailSettings> _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings;
    }
    
    public async Task<bool> SendEmailAsync(EmailMessage emailMessage)
    {
        var client  = new SendGridClient(_emailSettings.Value.ApiKey);
        var from = new EmailAddress(_emailSettings.Value.FromAddress, _emailSettings.Value.FromName);
        var to = new EmailAddress(emailMessage.To);
        
        var msg = MailHelper.CreateSingleEmail(from, to, emailMessage.Subject, emailMessage.Body, emailMessage.Body);
        var response = await client.SendEmailAsync(msg);
        
        return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
    }
}