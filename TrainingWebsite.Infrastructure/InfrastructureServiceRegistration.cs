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
            options.ApiKey = configuration["EmailSettings:ApiKey"] ?? throw new InvalidOperationException();
            options.FromName = configuration["EmailSettings:FromName"] ?? throw new InvalidOperationException();
            options.FromAddress = configuration["EmailSettings:FromAddress"] ?? throw new InvalidOperationException();
        }));
        
        services.AddTransient<IEmailSender, EmailSender>();
        
        // Register Logging Service
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        
        

        return services;
    }
    
}