using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingWebsite.Application.Contracts.Identity;
using TrainingWebsite.Application.Models.Identity;
using TrainingWebsite.Identity.Models;

namespace TrainingWebsite.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<List<User>> GetUsers()
    {
        // Get all users in the User role
        var users = await _userManager.GetUsersInRoleAsync("User");
        return users.Select(u => new User
        {
            Id = u.Id,
            Email = u.Email,
            FirstName = u.FirstName,
            LastName = u.LastName
        }).ToList();
    }

    public async Task<User> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return new User
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}