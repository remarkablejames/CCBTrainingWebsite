using TrainingWebsite.Application.Models.Identity;

namespace TrainingWebsite.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}