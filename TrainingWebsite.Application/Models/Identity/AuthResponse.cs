namespace TrainingWebsite.Application.Models.Identity;

public class AuthResponse
{
    public string Id { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string UserName { get; set; } = String.Empty;
    public string Token { get; set; } = String.Empty;
}