using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.DI;

public class Provider
{
    public ServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<IInteractiveService, InteractiveService>()
            .AddSingleton<CommandService>()
            .AddSingleton<ICommandHandler, CommandHandler>()
            .BuildServiceProvider();
    }
}