using Discord.Commands;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Modules;

public class TestModule : ModuleBase<SocketCommandContext>
{
    [Command("test")]
    [Summary("Echo a message")]
    public Task SayAsync() 
        => ReplyAsync("test");
}