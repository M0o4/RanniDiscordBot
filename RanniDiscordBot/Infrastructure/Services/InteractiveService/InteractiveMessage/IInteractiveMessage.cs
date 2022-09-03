using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage;

public interface IInteractiveMessage
{
    public Task Interact(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> chanel, SocketReaction reaction);
}