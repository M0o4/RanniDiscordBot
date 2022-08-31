using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services;

public class CommandHandler : ICommandHandler
{
    private readonly DiscordSocketClient _client;
    private readonly CommandService _commands;
    private readonly IServiceProvider _services;

    public CommandHandler(DiscordSocketClient client, CommandService commands, IServiceProvider services)
    {
        _client = client;
        _commands = commands;
        _services = services;
    }

    public async Task InstallCommandsAsync()
    {
        Console.WriteLine("InstallCommandsAsync");
        _client.MessageReceived += HandleCommandAsync;
        
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), 
            _services);
    }

    private async Task HandleCommandAsync(SocketMessage message)
    {
        if (message is not SocketUserMessage userMessage) return;

        int argPos = 0;

        if (!(userMessage.HasCharPrefix('!', ref argPos) ||
              userMessage.HasMentionPrefix(_client.CurrentUser, ref argPos))
            || userMessage.Author.IsBot) return;

        var context = new SocketCommandContext(_client, userMessage);

        await _commands.ExecuteAsync(
            context: context, 
            argPos: argPos, 
            services: null);
    }
}