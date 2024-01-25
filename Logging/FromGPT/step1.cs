//dotnet add package Microsoft.Extensions.Logging

public class LogService
{
    private readonly ILogger<LogService> _logger;

    public LogService(ILogger<LogService> logger)
    {
        _logger = logger;
    }

    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogError(string message, Exception ex)
    {
        _logger.LogError(ex, message);
    }
}
