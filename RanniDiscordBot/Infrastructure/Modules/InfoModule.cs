using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Modules;

public class InfoModule : ModuleBase<SocketCommandContext>
{
    private readonly CommandService _commands;
    private readonly ILogger _logger;

    public InfoModule(CommandService commands, ILogger logger)
    {
        _logger = logger;
        _commands = commands;
    }
        
    [Command("cmd")]
    [Summary("Command list")]
    public Task PrintCommandAsync()
    {
        _logger.LogDebug("Cmd");
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