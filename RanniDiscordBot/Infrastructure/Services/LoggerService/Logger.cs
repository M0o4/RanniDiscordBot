using Discord;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

public class Logger : ILogger
{
    public Task Log(LogMessage message)
    {
        SetConsoleColor(message.Severity);
        Console.WriteLine(message.ToString());
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