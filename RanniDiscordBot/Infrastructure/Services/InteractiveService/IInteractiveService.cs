using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;

public interface IInteractiveService
{
    void AddInteractMessage(ulong messageId, IInteractiveMessage pageMessage);
}