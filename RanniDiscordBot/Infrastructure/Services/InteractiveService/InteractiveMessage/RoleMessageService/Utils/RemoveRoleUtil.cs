using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.RoleMessageService.Utils;

public class RemoveRoleUtil : RoleUtil
{
    public override void HandleRole(string roleName, Cacheable<IMessageChannel, ulong> chanel, SocketReaction reaction)
    {
        var user = GetUser(reaction);
        var role = GetRole(roleName, chanel);

        if (user != null && user.Guild.Roles.Contains(role)) 
            user.RemoveRoleAsync(role);
    }

    private static IGuildUser? GetUser(SocketReaction reaction) => 
        reaction.User.Value as IGuildUser;

    private SocketRole? GetRole(string roleName, Cacheable<IMessageChannel, ulong> chanel) =>
        (chanel.Value as SocketGuildChannel)?.Guild.Roles.FirstOrDefault(r => r.Name == roleName);
}