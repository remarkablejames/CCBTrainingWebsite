using MediatR;

namespace TrainingWebsite.Application.Features.Training.Commands.CreateTraining;

public class CreateTrainingCommand: IRequest<Guid>
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
}