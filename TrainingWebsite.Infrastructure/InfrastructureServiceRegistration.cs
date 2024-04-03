using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainingWebsite.Application.Contracts.Email;
using TrainingWebsite.Application.Models.Email;
using TrainingWebsite.Infrastructure.EmailService;

namespace TrainingWebsite.Infrastructure;

public static class InfrastructureServiceRegistration
{
    
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure((Action<EmailSettings>)(options =>
        {
            options.ApiKey = configuration["SendGrid:ApiKey"] ?? throw new InvalidOperationException();
            options.FromName = configuration["SendGrid:FromName"] ?? throw new InvalidOperationException();
            options.FromAddress = configuration["SendGrid:FromAddress"] ?? throw new InvalidOperationException();
        }));
        
        services.AddTransient<IEmailSender, EmailSender>();
        

        return services;
    }
    
}