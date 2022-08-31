using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.PageMessageService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;

public interface IInteractiveService
{
    void AddPageMessage(ulong messageId, PageMessage pageMessage);
}