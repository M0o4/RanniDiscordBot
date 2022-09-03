namespace RanniDiscordBot.RanniDiscordBot.Configuration;

[Serializable]
public class Config
{
    public RoleMessageData RoleMessageData { get; set; }
    public RolesData RolesData { get; set; }

    public Config()
    {
        RoleMessageData = new RoleMessageData();
        RolesData = new RolesData();
    }
}