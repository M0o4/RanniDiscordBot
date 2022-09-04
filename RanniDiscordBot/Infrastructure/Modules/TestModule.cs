using Discord;
using Discord.Commands;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Modules;

public class TestModule : ModuleBase<SocketCommandContext>
{
    [Discord.Commands.RequireOwner]
    [Command("test")]
    [Summary("test module")]
    public async Task SayAsync()
    {
        await ReplyAsync($"{Context.Guild.Roles.FirstOrDefault(r => r.Name == "1 курс")?.Name}");
        await (Context.User as IGuildUser)?.AddRoleAsync(
            Context.Guild.Roles.FirstOrDefault(r => r.Name == "1 курс"))!;
        await ReplyAsync("test");
    }
}