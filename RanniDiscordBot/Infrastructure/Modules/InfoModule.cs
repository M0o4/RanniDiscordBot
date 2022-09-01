using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Modules;

public class InfoModule : ModuleBase<SocketCommandContext>
{
    private readonly CommandService _commands;

    public InfoModule(CommandService commands)
    {
        _commands = commands;
    }
        
    [Command("cmd")]
    [Summary("Command list")]
    public Task PrintCommandAsync()
    {
        var commands = string.Empty;
        if(string.IsNullOrEmpty(commands))
        {
            foreach (var module in _commands.Modules)
            {
                foreach (var command in module.Commands)
                {
                    commands += $"!{command.Name} - {command.Summary ?? "No description provided"}\n";
                }
            }
        }
        return ReplyAsync(commands);
    }
    
    // [Command("test")]
    // [Summary("Command")]
    // public Task PrintTestAsync()
    // {
    //     string guilds = string.Empty;
    //
    //     foreach (var guild in _client.Guilds)
    //     {
    //         guilds += $"{guild.Name},";
    //     }
    //     return ReplyAsync(guilds);
    // }
    
    [Command("say")]
    [Summary("Echo a message")]
    public Task SayAsync([Remainder] [Summary("The text to echo")] string echo) 
        => ReplyAsync(echo);
}