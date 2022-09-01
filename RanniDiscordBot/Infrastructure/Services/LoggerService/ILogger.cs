using Discord;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

public interface ILogger
{
    Task Log(LogMessage message);
}