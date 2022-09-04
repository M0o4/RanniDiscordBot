using Newtonsoft.Json;
using RanniDiscordBot.RanniDiscordBot.Utils;

namespace RanniDiscordBot.RanniDiscordBot.Configuration;

public class Server : IServer
{
    public Config? Config => _config;
    
    private const string ConfigPath = @"config.json";

    private Config? _config;

    public Server() => 
        LoadOrCreateData();

    public void LoadOrCreateData()
    {
        if (File.Exists(ConfigPath))
            LoadConfig();
        else
        {
            CreateConfig();
            SaveData();
        }
    }

    public void SaveData() =>
        DataUtils.SaveJson(ConfigPath, _config);

    private void LoadConfig()
    {
        using StreamReader reader = new StreamReader(ConfigPath);
        var json = reader.ReadToEnd();
        _config = JsonConvert.DeserializeObject<Config>(json);
    }

    private void CreateConfig() =>
        _config = new Config();
}