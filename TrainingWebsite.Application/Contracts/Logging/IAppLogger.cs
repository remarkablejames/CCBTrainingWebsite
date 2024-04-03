namespace TrainingWebsite.Application.Contracts.Logging;

public interface IAppLogger<T>
{
    void LogWarning(string message, params object[] args);
    void LogInformation(string message, params object[] args);
    
}