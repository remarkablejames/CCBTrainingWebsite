using MediatR;

namespace TrainingWebsite.Application.Features.Training.Queries.GetAllTrainings;

public record GetAllTrainingsQuery : IRequest<List<TrainingDto>>;