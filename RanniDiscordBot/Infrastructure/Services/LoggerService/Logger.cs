using System.Diagnostics;
using Discord;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

public class Logger : ILogger
{
    public async void LogCritical(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Critical, NameOfCallingClass(), message));
    public async void LogError(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Error, NameOfCallingClass(), message));
    
    public async void LogWarning(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Warning, NameOfCallingClass(), message));
    
    public async void LogInfo(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Info, NameOfCallingClass(), message));
    
    public async void LogVerbose(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Verbose, NameOfCallingClass(), message));
    
    public async void LogDebug(string source, string message) => 
        await Log(new LogMessage(LogSeverity.Debug, NameOfCallingClass(), message));

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

    private string? NameOfCallingClass()
    {
        var methodInfo = new StackTrace().GetFrame(5)?.GetMethod();
        var className = methodInfo?.ReflectedType?.Name;
        
        return className;
    }
}