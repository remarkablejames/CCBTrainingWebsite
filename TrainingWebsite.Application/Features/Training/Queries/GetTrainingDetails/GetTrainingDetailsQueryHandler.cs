using AutoMapper;
using MediatR;
using TrainingWebsite.Application.Contracts.Persistence;
using TrainingWebsite.Application.Exceptions;

namespace TrainingWebsite.Application.Features.Training.Queries.GetTrainingDetails;

public class GetTrainingDetailsQueryHandler: IRequestHandler<GetTrainingDetailsQuery, TrainingDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ITrainingRepository _trainingRepository;

    public GetTrainingDetailsQueryHandler(IMapper mapper, ITrainingRepository trainingRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
    }
    public async Task<TrainingDetailsDto> Handle(GetTrainingDetailsQuery request, CancellationToken cancellationToken)
    {
        // get the training by id from the repository
        var training = await _trainingRepository.GetByIdAsync(request.TrainingId);
        
        // check if the training is null
        if (training is null)
        {
            throw new NotFoundException(nameof(Domain.Training), request.TrainingId);
        }
        
        // return the training details
        return _mapper.Map<TrainingDetailsDto>(training);
    }
}