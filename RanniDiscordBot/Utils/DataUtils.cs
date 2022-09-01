using System.Text.Json;

namespace RanniDiscordBot.RanniDiscordBot.Utils;

public static class DataUtils
{
    public static void SaveJson<T>(string path, T value)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
            
        var json = JsonSerializer.Serialize(value, options);
        File.WriteAllText(path, json);
    }
}