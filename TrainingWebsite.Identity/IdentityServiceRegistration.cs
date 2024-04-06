using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainingWebsite.Application.Models.Identity;
using TrainingWebsite.Identity.Models;

namespace TrainingWebsite.Identity;

public static class IdentityServiceRegistration
{
    // public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    // {
    //     services.AddDbContext<ApplicationDbContext>(options =>
    //     {
    //         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    //     });
    //
    //     services.AddIdentity<ApplicationUser, IdentityRole>()
    //         .AddEntityFrameworkStores<ApplicationDbContext>()
    //         .AddDefaultTokenProviders();
    //
    //     services.Configure<IdentityOptions>(options =>
    //     {
    //         options.Password.RequireDigit = true;
    //         options.Password.RequireLowercase = true;
    //         options.Password.RequireNonAlphanumeric = true;
    //         options.Password.RequireUppercase = true;
    //         options.Password.RequiredLength = 8;
    //         options.Password.RequiredUniqueChars = 1;
    //
    //         options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //         options.Lockout.MaxFailedAccessAttempts = 5;
    //         options.Lockout.AllowedForNewUsers = true;
    //
    //         options.User.AllowedUserNameCharacters =
    //             "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    //         options.User.RequireUniqueEmail = true;
    //     });
    //
    //     services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
    //
    //     services.AddScoped<IIdentityService, IdentityService>();
    //
    //     return services;
    // }
    
}