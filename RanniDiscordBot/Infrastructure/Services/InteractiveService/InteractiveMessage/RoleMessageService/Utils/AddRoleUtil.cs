using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.
    RoleMessageService.Utils;

public class AddRoleUtil : RoleUtil
{
    public override void HandleRole(string roleName, Cacheable<IMessageChannel, ulong> chanel, SocketReaction reaction)
    {
        var role = GetRole(roleName, chanel);
        if (role != null)
            SetRole(reaction.User.Value, role);
    }
    
    private SocketRole? GetRole(string roleName, Cacheable<IMessageChannel, ulong> chanel) =>
        (chanel.Value as SocketGuildChannel)?.Guild.Roles.FirstOrDefault(r => r.Name == roleName);
    
    private void SetRole(IUser user, IRole role) => 
        (user as SocketGuildUser)?.AddRoleAsync(role);
}