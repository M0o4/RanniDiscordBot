using Discord;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

public interface ILogger
{
    Task Log(LogMessage message);
    void LogCritical(string source, string message);
    void LogError(string source, string message);
    void LogWarning(string source, string message);
    void LogInfo(string source, string message);
    void LogVerbose(string source, string message);
    void LogDebug(string source, string message);
}