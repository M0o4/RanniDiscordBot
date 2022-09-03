using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Configuration;

[Serializable]
public class RolesData
{
    public List<SocketRole> ServerRoles { get; set; }

    public RolesData()
    {
        ServerRoles = new List<SocketRole>();
    }
}