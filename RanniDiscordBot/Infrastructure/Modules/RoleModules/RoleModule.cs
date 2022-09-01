using Discord;
using Discord.Commands;
using Discord.WebSocket;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.RoleMessageService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Modules.RoleModules;

public class RoleModule : ModuleBase<SocketCommandContext>
{
    [Command("role")]
    [Summary("set role.")]
    public async Task PrintBlackListAsync()
    {
        var message = Context.Message.ReferencedMessage;

        await AddReactions(message);

        // _ = Task.Run(async () =>
        // {
        //     var list = BlackList.GetList(5);
        //     if (list.Count == 1)
        //     {
        //         await ReplyAsync(list[0]);
        //         return;
        //     }
        //     
        //     string page = $"{PageMessageEmote.PageEmoji}: {1}/{list.Count}";
        //     var message = await Context.Channel.SendMessageAsync($"```{list[0]}```{page}");
        //         
        //     Shinobu.InteractiveService.AddPageMessage(message.Id, new PageMessage(message, list.ToArray()));
        //     await message.AddReactionAsync(PageMessageEmote.Back);
        //     await message.AddReactionAsync(PageMessageEmote.Next);
        // });
    }

    private async Task AddReactions(IUserMessage message)
    {
        await message.AddReactionAsync(RoleMessageEmote.One);
        await message.AddReactionAsync(RoleMessageEmote.Two);
        await message.AddReactionAsync(RoleMessageEmote.Three);
        await message.AddReactionAsync(RoleMessageEmote.Four);
        await message.AddReactionAsync(RoleMessageEmote.Five);
    }

    // await Context.Message.ReferencedMessage.ReplyAsync(Switcher.Switch(Context.Message.ReferencedMessage.Content.ToLower()));
}