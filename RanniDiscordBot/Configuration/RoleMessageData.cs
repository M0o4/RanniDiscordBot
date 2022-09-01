using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.RoleMessageService;

namespace RanniDiscordBot.RanniDiscordBot.Configuration;

[Serializable]
public class RoleMessageData
{
    public RoleMessage RoleMessage { get; set; }
    public ulong RoleMessageID { get; set; }
}