using AutoMapper;
using Moq;
using Shouldly;
using TrainingWebsite.Application.Contracts.Logging;
using TrainingWebsite.Application.Contracts.Persistence;
using TrainingWebsite.Application.Features.Training.Queries.GetAllTrainings;
using TrainingWebsite.Application.MappingProfiles;
using TrainingWebsite.Mocks;
using Xunit.Abstractions;

namespace TrainingWebsite.Features.Trainings.Queries;

public class GetTrainingListQueryHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<ITrainingRepository> _mockTrainingRepository;
    private readonly IMapper _mapper;
    private readonly Mock<IAppLogger<GetAllTrainingsQueryHandler>> _mockAppLogger;

    public GetTrainingListQueryHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockTrainingRepository = MockTrainingRepository.GetTrainings();
        var mapperConfig = new MapperConfiguration(c => { c.AddProfile<TrainingProfiles>(); });

        _mapper = mapperConfig.CreateMapper();

        // mock applogger
        _mockAppLogger = new Mock<IAppLogger<GetAllTrainingsQueryHandler>>();
    }

    [Fact]
    public async Task GetTrainingListTests()
    {
        var handler = new GetAllTrainingsQueryHandler(_mapper, _mockTrainingRepository.Object, _mockAppLogger.Object);

        var result = await handler.Handle(new GetAllTrainingsQuery(), CancellationToken.None);
        // _testOutputHelper.WriteLine(result.ToString());

        result.ShouldBeOfType<List<TrainingDto>>();
        // result.Count.ShouldBe(3);
    }


}
    