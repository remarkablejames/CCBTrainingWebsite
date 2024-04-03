using System.Collections;
using FluentValidation.Results;

namespace TrainingWebsite.Application.Exceptions;

public class BadRequestException:Exception
{
    public BadRequestException(string message) : base(message)
    {
    }
    
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
    
    public IDictionary<string, string[]> ValidationErrors { get; } = new Dictionary<string, string[]>();
    
}