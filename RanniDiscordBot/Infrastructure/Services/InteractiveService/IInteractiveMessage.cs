using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;

public interface IInteractiveMessage
{
    public IUserMessage Message { get; }

    public string Interact(SocketReaction reaction);
}