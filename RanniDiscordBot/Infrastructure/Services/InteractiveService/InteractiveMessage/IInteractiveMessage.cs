using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage;

public interface IInteractiveMessage
{
    public Task Interact(SocketReaction reaction);
}