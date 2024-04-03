using MediatR;

namespace TrainingWebsite.Application.Features.Training.Queries.GetTrainingDetails;

public record GetTrainingDetailsQuery(Guid TrainingId): IRequest<TrainingDetailsDto>;