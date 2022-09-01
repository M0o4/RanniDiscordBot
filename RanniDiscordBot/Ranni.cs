using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.DI;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

namespace RanniDiscordBot.RanniDiscordBot;

public class Ranni
{
    private const string TokenPath = "token.txt";

    private readonly DiscordSocketClient _client;
    private readonly ICommandHandler _commandHandler;
    private readonly ILogger _logger;

    public Ranni()
    {
        IServiceProvider service = new Provider().ConfigureServices();
        
        _client = service.GetRequiredService<DiscordSocketClient>();
        _logger = service.GetRequiredService<ILogger>();
        _commandHandler = service.GetRequiredService<ICommandHandler>();
    }

    public async Task StartBotAsync()
    {
        await _commandHandler.InstallCommandsAsync();

        _client.Log += _logger.Log;

        var token = await File.ReadAllTextAsync(TokenPath);

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }
}