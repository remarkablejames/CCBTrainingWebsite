using FluentValidation;

namespace TrainingWebsite.Application.Features.Training.Commands.CreateTraining;

public class CreateTrainingCommandValidator: AbstractValidator<CreateTrainingCommand>
{
    
    public CreateTrainingCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        
        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now);
        
        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(p => p.StartDate);
    }
    
}