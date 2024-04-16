using Moq;
using TrainingWebsite.Application.Contracts.Persistence;
using TrainingWebsite.Domain;

namespace TrainingWebsite.Mocks;

public class MockTrainingRepository
{
    public static Mock<ITrainingRepository> GetTrainings()
    {
        var trainings = new List<Training>
        {
            new Training
            {
                Id = Guid.NewGuid(),
                Name = "Training 1",
                Description = "Description 1",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2)

            },
            new Training
            {
                Id = Guid.NewGuid(),
                Name = "Training 1",
                Description = "Description 1",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2)
            },
            new Training
            {
                Id = Guid.NewGuid(),
                Name = "Training 2",
                Description = "Description 2",
                StartDate = DateTime.Now.AddDays(3),
                EndDate = DateTime.Now.AddDays(4)
            }
        };
        
        var trainingRepository = new Mock<ITrainingRepository>();
        
        trainingRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(trainings);
        trainingRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Guid trainingId) => trainings.FirstOrDefault(x => x.Id == trainingId));
        trainingRepository.Setup(repo => repo.AddAsync(It.IsAny<Training>()))
            .ReturnsAsync((Training training) =>
            {
                trainings.Add(training);
                return training;
            });
        return trainingRepository;
    }
}