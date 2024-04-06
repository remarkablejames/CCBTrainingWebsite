using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrainingWebsite.Identity.DbContext.Configurations;

public class UserRoleConfiguration: IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "6daa2064-54fb-466e-bd19-1a6ceb2a72eb",
                UserId = "e5fe4375-7298-48df-baa7-49f635c34b67"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a454b1d6-1702-4e77-b07c-54b9172628a0",
                UserId = "ea3e1e1c-be7e-4341-ad5a-fc84dfcc61b3"
            }
        );
    }
}