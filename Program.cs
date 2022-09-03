using RanniDiscordBot.RanniDiscordBot;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.DI;

IServiceProvider services = new Provider().ConfigureServices();

new Ranni(services).StartBotAsync().GetAwaiter().GetResult();