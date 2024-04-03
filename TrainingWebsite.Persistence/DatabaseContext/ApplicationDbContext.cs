using Microsoft.EntityFrameworkCore;
using TrainingWebsite.Domain;

namespace TrainingWebsite.Persistence.DatabaseContext;

public class ApplicationDbContext: DbContext
{
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Training> Trainings { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    
    
}