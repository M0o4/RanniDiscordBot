using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using RanniDiscordBot.RanniDiscordBot.Configuration;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.DI;

public class Provider
{
    public ServiceProvider ConfigureServices()
    {
        var client = CreateClient();

        return new ServiceCollection()
            .AddSingleton<IServer, Server>()
            .AddSingleton<ILogger, Logger>()
            .AddSingleton(client)
            .AddSingleton<IInteractiveService, InteractiveService>()
            .AddSingleton<CommandService>()
            .AddSingleton<ICommandHandler, CommandHandler>()
            .BuildServiceProvider();
    }

    private static DiscordSocketClient CreateClient()
    {
        var config = new DiscordSocketConfig()
        {
            GatewayIntents = GatewayIntents.DirectMessages | GatewayIntents.DirectMessages | GatewayIntents.GuildBans |
                             GatewayIntents.GuildIntegrations | GatewayIntents.GuildMembers |
                             GatewayIntents.GuildMessageReactions | GatewayIntents.GuildMessages | GatewayIntents.Guilds,
            MessageCacheSize = 15,
            LogLevel = LogSeverity.Info,
            ConnectionTimeout = int.MaxValue,
            AlwaysDownloadUsers = true,
        };

        var client = new DiscordSocketClient(config);
        return client;
    }
}