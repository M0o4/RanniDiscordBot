namespace RanniDiscordBot.RanniDiscordBot.Configuration;

[Serializable]
public class Config
{
    public RoleMessageData RoleMessageData { get; set; }

    public Config()
    {
        RoleMessageData = new RoleMessageData();
    }
}