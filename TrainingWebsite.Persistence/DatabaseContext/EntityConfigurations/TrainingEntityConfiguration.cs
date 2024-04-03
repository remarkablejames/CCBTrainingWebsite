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
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 1, 5),
            });
    }
}