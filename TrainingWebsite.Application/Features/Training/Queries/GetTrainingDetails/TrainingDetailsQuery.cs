using MediatR;

namespace TrainingWebsite.Application.Features.Training.Queries.GetTrainingDetails;

public record TrainingDetailsQuery(Guid TrainingId): IRequest<TrainingDetailsDto>;