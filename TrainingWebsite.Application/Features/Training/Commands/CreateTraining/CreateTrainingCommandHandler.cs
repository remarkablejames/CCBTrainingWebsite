using AutoMapper;
using MediatR;
using TrainingWebsite.Application.Contracts.Persistence;
using TrainingWebsite.Application.Exceptions;

namespace TrainingWebsite.Application.Features.Training.Commands.CreateTraining;

public class CreateTrainingCommandHandler: IRequestHandler<CreateTrainingCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly ITrainingRepository _trainingRepository;

    public CreateTrainingCommandHandler(IMapper mapper, ITrainingRepository trainingRepository)
    {
        _mapper = mapper;
        _trainingRepository = trainingRepository;
    }
    public async Task<Guid> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        
        var validator = new CreateTrainingCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Count > 0)
        {
            throw new BadRequestException("Invalid request", validationResult);
        }
        
        // Map the request to the entity using auto mapper
        var training = _mapper.Map<Domain.Training>(request);
        
        // Save the training to the database
        
        training = await _trainingRepository.AddAsync(training);
        
        return training.Id;
    }
}