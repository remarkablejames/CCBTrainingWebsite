namespace TrainingWebsite.Application.Features.Training.Queries.GetTrainingDetails;

public class TrainingDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}