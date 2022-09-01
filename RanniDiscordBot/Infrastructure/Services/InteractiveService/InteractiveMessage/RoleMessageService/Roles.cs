using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.RoleMessageService;

[Serializable]
public static class Roles
{
    public static List<SocketRole> ServerRoles { get; set; }
}