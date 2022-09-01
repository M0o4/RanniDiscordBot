using Newtonsoft.Json;
using RanniDiscordBot.RanniDiscordBot.Utils;

namespace RanniDiscordBot.RanniDiscordBot.Configuration;

public static class Server
{
    private const string ConfigPath = @"config.json";

    private static Config? _config;

    public static void LoadOrCreateData()
    {
        if (File.Exists(ConfigPath))
            LoadConfig();
        else
        {
            CreateConfig();
            SaveData();
        }
        
    }

    private static void LoadConfig()
    {
        using StreamReader reader = new StreamReader(ConfigPath);
        var json = reader.ReadToEnd();
        _config = JsonConvert.DeserializeObject<Config>(json);
    }

    private static void CreateConfig() => 
        _config = new Config();

    private static void SaveData() => 
        DataUtils.SaveJson(ConfigPath, _config);
}