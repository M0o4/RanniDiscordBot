using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using RanniDiscordBot.RanniDiscordBot.Configuration;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

namespace RanniDiscordBot.RanniDiscordBot;

public class Ranni
{
    private const string TokenPath = "token.txt";

    private readonly DiscordSocketClient _client;
    private readonly ICommandHandler _commandHandler;
    private readonly ILogger _logger;
    private readonly IServer _server;

    public Ranni(IServiceProvider services)
    {
        _server = services.GetRequiredService<IServer>();
        _client = services.GetRequiredService<DiscordSocketClient>();
        _logger = services.GetRequiredService<ILogger>();
        _commandHandler = services.GetRequiredService<ICommandHandler>();
    }

    public async Task StartBotAsync()
    {
        _server.LoadOrCreateData();
        
        await _commandHandler.InstallCommandsAsync();

        _client.Log += _logger.Log;

        var token = await File.ReadAllTextAsync(TokenPath);

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }
}