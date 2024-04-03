namespace TrainingWebsite.Application.Features.Training.Queries.GetAllTrainings;

public class TrainingDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}