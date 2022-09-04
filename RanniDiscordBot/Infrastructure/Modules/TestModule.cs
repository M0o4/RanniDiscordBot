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

    [RequireOwner]
    [Command("Roles")]
    [Summary("Print all roles")]
    public Task PrintRolesAsync()
    {
        var roles = string.Empty;

        _ = Task.Run(async () =>
        {
            foreach (var role in Context.Guild.Roles)
            {
                roles += $"\"{role.Name}\",";
            }

            await ReplyAsync(roles);
        });

        return Task.CompletedTask;
    }
}