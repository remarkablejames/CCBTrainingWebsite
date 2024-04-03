using AutoMapper;
using TrainingWebsite.Application.Features.Training.Commands.CreateTraining;
using TrainingWebsite.Application.Features.Training.Queries.GetAllTrainings;
using TrainingWebsite.Application.Features.Training.Queries.GetTrainingDetails;
using TrainingWebsite.Domain;

namespace TrainingWebsite.Application.MappingProfiles;

public class TrainingProfiles: Profile
{
    // Here we will define the mapping between the source and destination objects
    public TrainingProfiles()
    {
        CreateMap<Training, TrainingDto>().ReverseMap();
        CreateMap<Training, TrainingDetailsDto>();
        CreateMap<CreateTrainingCommand, Training>(); // This will map the CreateTrainingCommand to Training when a new training is created. no need to reverse map
    }
    
}