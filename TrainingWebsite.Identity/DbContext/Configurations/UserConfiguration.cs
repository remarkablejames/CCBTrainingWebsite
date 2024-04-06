using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingWebsite.Identity.Models;

namespace TrainingWebsite.Identity.DbContext.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
            new ApplicationUser
            {
                Id = "e5fe4375-7298-48df-baa7-49f635c34b67",
                FirstName = "John",
                LastName = "Doe",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                },
            
            new ApplicationUser
            {
                Id = "ea3e1e1c-be7e-4341-ad5a-fc84dfcc61b3",
                FirstName = "Jane",
                LastName = "Doe",
                UserName = "user@localhost.com",
                NormalizedUserName = "USER@LOCALHOST.COM",
                Email = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "User@123"),
                });
            
    }
}