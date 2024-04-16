using Microsoft.EntityFrameworkCore;
using Shouldly;
using TrainingWebsite.Domain;
using TrainingWebsite.Persistence.DatabaseContext;

namespace TrainingWebsite.IntegrationTests;

public class ApplicationDbContextTests
{
    private readonly ApplicationDbContext _dbContext;

    public ApplicationDbContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _dbContext = new ApplicationDbContext(dbOptions);
    }
    [Fact]
    public async void New_Training_Has_Name()
    {
        // Arrange
        var training = new Training {
            Id = Guid.NewGuid(),
            Name = "Training 1",
            Description = "Description 1",
            StartDate = DateTime.Now.AddDays(1),
            EndDate = DateTime.Now.AddDays(2)

        };
        
        // Act
        await _dbContext.Trainings.AddAsync(training);
        await _dbContext.SaveChangesAsync();
        
        // Assert
        var trainingFromDb = await _dbContext.Trainings.FirstOrDefaultAsync(x => x.Id == training.Id);

        trainingFromDb.ShouldNotBeNull();
        trainingFromDb.Name.ShouldBe("Training 1");
    }
}