using AutoMapper;
using MediatR;
using TrainingWebsite.Application.Contracts.Logging;
using TrainingWebsite.Application.Contracts.Persistence;

namespace TrainingWebsite.Application.Features.Training.Queries.GetAllTrainings;

public class GetAllTrainingsQueryHandler:IRequestHandler<GetAllTrainingsQuery, List<TrainingDto>>
{
    private readonly IMapper _mapper;
    private readonly ITrainingRepository _repository;
    private readonly IAppLogger<GetAllTrainingsQueryHandler> _logger;

    public GetAllTrainingsQueryHandler(IMapper mapper, ITrainingRepository repository, IAppLogger<GetAllTrainingsQueryHandler> logger)
    {
        _mapper = mapper;
        _repository = repository;
        _logger = logger;
    }
    public async Task<List<TrainingDto>> Handle(GetAllTrainingsQuery request, CancellationToken cancellationToken)
    {
        // Here we will write the logic to get all the trainings from the database
        
        //1. Get all the trainings from the database
        var trainings = await _repository.GetAllAsync();
        //2. Map the training to TrainingDto Return the list of TrainingDto
        
        _logger.LogInformation("---->>>>>>>>GetAllTrainingsQueryHandler called and returned all trainings.");
        return _mapper.Map<List<TrainingDto>>(trainings);
    }
}