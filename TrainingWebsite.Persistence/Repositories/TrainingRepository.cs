using TrainingWebsite.Application.Contracts.Persistence;
using TrainingWebsite.Domain;
using TrainingWebsite.Persistence.DatabaseContext;

namespace TrainingWebsite.Persistence.Repositories;

public class TrainingRepository: GenericRepository<Training>, ITrainingRepository
{
    public TrainingRepository(ApplicationDbContext context) : base(context)
    {
    }
    
}