using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingWebsite.Domain;

namespace TrainingWebsite.Persistence.DatabaseContext.EntityConfigurations;

public class TrainingEntityConfiguration:IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.HasData(
            new Training()
            {
                Id = Guid.NewGuid(),
                Name = "C# Fundamentals",
                Description = "C# Fundamentals Training",
                // UtcNow is used to get the current date and time in Coordinated Universal Time (UTC)
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(5)
            });
    }
}