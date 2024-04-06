using TrainingWebsite.Application.Models.Identity;

namespace TrainingWebsite.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUser(string userId);
    
}