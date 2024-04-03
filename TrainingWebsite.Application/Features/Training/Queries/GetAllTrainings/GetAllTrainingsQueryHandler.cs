using AutoMapper;
using MediatR;
using TrainingWebsite.Application.Contracts.Persistence;

namespace TrainingWebsite.Application.Features.Training.Queries.GetAllTrainings;

public class GetAllTrainingsQueryHandler:IRequestHandler<GetAllTrainingsQuery, List<TrainingDto>>
{
    private readonly IMapper _mapper;
    private readonly ITrainingRepository _repository;

    public GetAllTrainingsQueryHandler(IMapper mapper, ITrainingRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<List<TrainingDto>> Handle(GetAllTrainingsQuery request, CancellationToken cancellationToken)
    {
        // Here we will write the logic to get all the trainings from the database
        
        //1. Get all the trainings from the database
        var trainings = await _repository.GetAllAsync();
        //2. Map the training to TrainingDto Return the list of TrainingDto
        return _mapper.Map<List<TrainingDto>>(trainings);
    }
}