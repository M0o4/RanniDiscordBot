using Discord;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

public interface ILogger
{
    Task Log(LogMessage message);
    void LogCritical(string message);
    void LogError(string message);
    void LogWarning(string message);
    void LogInfo(string message);
    void LogVerbose(string message);
    void LogDebug(string message);
}