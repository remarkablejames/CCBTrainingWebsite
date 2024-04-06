using System.Collections;
using FluentValidation.Results;

namespace TrainingWebsite.Application.Exceptions;

public class UnAuthorizedException:Exception
{
    public UnAuthorizedException(string message) : base(message)
    {
    }
    
    public UnAuthorizedException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
    
    public IDictionary<string, string[]> ValidationErrors { get; } = new Dictionary<string, string[]>();
    
}