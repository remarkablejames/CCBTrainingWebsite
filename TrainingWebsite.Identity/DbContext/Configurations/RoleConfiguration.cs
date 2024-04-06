using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrainingWebsite.Identity.DbContext.Configurations;

public class RoleConfiguration: IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "6daa2064-54fb-466e-bd19-1a6ceb2a72eb", // Imade them static so that they don't change on every migration
                Name = "Adminstrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole
            {
                Id = "a454b1d6-1702-4e77-b07c-54b9172628a0",
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }
}