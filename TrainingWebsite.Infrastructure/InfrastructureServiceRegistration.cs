using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainingWebsite.Application.Contracts.Email;
using TrainingWebsite.Application.Contracts.Logging;
using TrainingWebsite.Application.Models.Email;
using TrainingWebsite.Infrastructure.Services.EmailService;
using TrainingWebsite.Infrastructure.Services.Logging;

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
        
        // Register Logging Service
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        
        

        return services;
    }
    
}