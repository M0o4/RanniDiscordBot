using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.RoleMessageService.Utils;

public abstract class RoleUtil
{
    public abstract void HandleRole(string roleName, Cacheable<IMessageChannel, ulong> chanel,
        SocketReaction reaction);
}