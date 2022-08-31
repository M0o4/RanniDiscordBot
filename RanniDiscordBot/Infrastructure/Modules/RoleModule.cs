using Discord;
using Discord.Commands;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessageService;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.PageMessageService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Modules;

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
        await message.AddReactionAsync(InteractiveMessageEmote.One);
        await message.AddReactionAsync(InteractiveMessageEmote.Two);
        await message.AddReactionAsync(InteractiveMessageEmote.Three);
        await message.AddReactionAsync(InteractiveMessageEmote.Four);
        await message.AddReactionAsync(InteractiveMessageEmote.Five);
    }

    // await Context.Message.ReferencedMessage.ReplyAsync(Switcher.Switch(Context.Message.ReferencedMessage.Content.ToLower()));
}