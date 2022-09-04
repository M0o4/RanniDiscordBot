namespace RanniDiscordBot.RanniDiscordBot.Configuration;

public interface IServer
{
    void LoadOrCreateData();
    Config? Config { get; }
    void SaveData();
}