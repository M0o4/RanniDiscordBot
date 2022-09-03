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
        return new ServiceCollection()
            .AddSingleton<IServer, Server>()
            .AddSingleton<ILogger, Logger>()
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<IInteractiveService, InteractiveService>()
            .AddSingleton<CommandService>()
            .AddSingleton<ICommandHandler, CommandHandler>()
            .BuildServiceProvider();
    }
}