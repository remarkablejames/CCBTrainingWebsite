using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
    public  async Task<AuthResponse> Login(AuthRequest request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        
        if (existingUser == null)
        {
            throw new NotFoundException($"User not found with Email: {request.Email}", request.Email);
        }
        
        JwtSecurityToken jwtSecurityToken = await GenerateJwtToken(existingUser);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        
        return new AuthResponse
        {
            Id = existingUser.Id,
            Token = token,
            Email = existingUser.Email,
            UserName = existingUser.UserName
        };
    }

    private async Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser existingUser)
    {
        var userClaims = await _userManager.GetClaimsAsync(existingUser);
        var roles = await _userManager.GetRolesAsync(existingUser);
        
        var roleClaims = roles.Select(role => new Claim("roles", role)).ToList();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, existingUser.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, existingUser.Email),
            new Claim("uid", existingUser.Id)
        }.Union(userClaims).Union(roleClaims);
        
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Value.Issuer,
            audience: _jwtSettings.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.Value.DurationInMinutes),
            signingCredentials: signingCredentials);
        
        return jwtSecurityToken;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        var newUser = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailConfirmed = true
        };
        
        var result = _userManager.CreateAsync(newUser, request.Password).Result;
        
        if (!result.Succeeded)
        {
            StringBuilder str = new StringBuilder();
            foreach (var error in result.Errors)
            {
                str.AppendFormat("{0}\n ", error.Description);
            }
            throw new BadRequestException(str.ToString());
        }
        
        await  _userManager.AddToRoleAsync(newUser, "User");
        
        return new RegistrationResponse
        {
            UserId = newUser.Id,
        };
        
    }
}