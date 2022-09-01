using Discord;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

public class Logger : ILogger
{
    public async void LogCritical(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Critical, source, message));
    public async void LogError(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Error, source, message));
    
    public async void LogWarning(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Warning, source, message));
    
    public async void LogInfo(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Info, source, message));
    
    public async void LogVerbose(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Verbose, source, message));
    
    public async void LogDebug(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Debug, source, message));

    public Task Log(LogMessage message)
    {
        SetConsoleColor(message.Severity);
        Console.WriteLine($"{Enum.GetName(typeof(LogSeverity), message.Severity)}\t\t{message.ToString()}");
        SetDefaultColor();
        return Task.CompletedTask;
    }

    private void SetConsoleColor(LogSeverity severity)
    {
        switch (severity)
        {
            case LogSeverity.Critical:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
            case LogSeverity.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case LogSeverity.Warning:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            case LogSeverity.Info:
                SetDefaultColor();
                break;
            case LogSeverity.Verbose:
                SetDefaultColor();
                break;
            case LogSeverity.Debug:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(severity), severity, null);
        }
    }

    private void SetDefaultColor() =>
        Console.ForegroundColor = ConsoleColor.White;
}