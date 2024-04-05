using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TrainingWebsite.Application.Contracts.Identity;
using TrainingWebsite.Application.Exceptions;
using TrainingWebsite.Application.Models.Identity;
using TrainingWebsite.Identity.Models;

namespace TrainingWebsite.Identity.Services;

public class AuthService: IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOptions<JwtSettings> _jwtSettings;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthService(UserManager<ApplicationUser> userManager,IOptions<JwtSettings> jwtSettings, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
        _signInManager = signInManager;
    }
    public  Task<AuthResponse> Login(AuthRequest request)
    {
        throw new NotImplementedException();
        
        // JwtSecurityToken jwtSecurityToken = await GenerateJwtToken(existingUser);
    }

    public Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        throw new NotImplementedException();
    }
}