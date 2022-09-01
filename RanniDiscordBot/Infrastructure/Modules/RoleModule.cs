using Discord;
using Discord.Commands;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.RoleMessageService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Modules;

public class RoleModule : ModuleBase<SocketCommandContext>
{
    private readonly IInteractiveService _interactiveMessage;

    public RoleModule(IInteractiveService interactiveMessage)
    {
        _interactiveMessage = interactiveMessage;
    }

    [Command("role")]
    [Summary("set role message.")]
    public Task SetRoleMessageAsync()
    {
        var message = Context.Message.ReferencedMessage;

        _ = Task.Run(async () =>
        {
            Roles.ServerRoles = Context.Guild.Roles.ToList();

            await AddReactions(message);
            
            _interactiveMessage.AddInteractMessage(Context.Message.Id, new RoleMessage());
        });
        
        return Task.CompletedTask;
    }

    private async Task AddReactions(IMessage message)
    {
        await message.AddReactionAsync(RoleMessageEmote.One);
        await message.AddReactionAsync(RoleMessageEmote.Two);
        await message.AddReactionAsync(RoleMessageEmote.Three);
        await message.AddReactionAsync(RoleMessageEmote.Four);
        await message.AddReactionAsync(RoleMessageEmote.Five);
    }

    // await Context.Message.ReferencedMessage.ReplyAsync(Switcher.Switch(Context.Message.ReferencedMessage.Content.ToLower()));
}