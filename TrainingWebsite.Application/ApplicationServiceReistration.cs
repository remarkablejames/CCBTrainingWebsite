using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TrainingWebsite.Application;

public static class ApplicationServiceReistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}