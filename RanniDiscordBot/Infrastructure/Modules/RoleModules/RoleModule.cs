using Discord;
using Discord.Commands;
using RanniDiscordBot.RanniDiscordBot.Configuration;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.RoleMessageService;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Modules.RoleModules;

public class RoleModule : ModuleBase<SocketCommandContext>
{
    private readonly IInteractiveService _interactiveMessage;
    private readonly ILogger _logger;
    private readonly IServer _server;

    public RoleModule(IInteractiveService interactiveMessage, ILogger logger, IServer server)
    {
        _server = server;
        _logger = logger;
        _interactiveMessage = interactiveMessage;
    }

    [Discord.Commands.RequireOwner]
    [Command("role")]
    [Discord.Commands.Summary("set role message.")]
    public Task SetRoleMessageAsync()
    {
        var message = Context.Message.ReferencedMessage;

        _ = Task.Run(async () =>
        {
            var roleMessage = new RoleMessage();

            _logger.LogDebug("Add roles");
            
            _logger.LogDebug("Add reactions");

            _interactiveMessage.AddInteractMessage(message.Id, roleMessage);
           
            _logger.LogDebug($"Add RoleMessage: {message.Id}");
           
            SaveRoleMessage(message.Id, roleMessage);
            
            _logger.LogDebug($"Create RoleMessage: {message.Id}");

            await AddReactions(message);
        });
        
        _logger.LogInfo("Done");

        return Task.CompletedTask;
    }

    private void SaveRoleMessage(ulong messageId, RoleMessage roleMessage)
    {
        if (_server.Config != null)
        {
            _server.Config.RoleMessageData.RoleMessageId = messageId;
            _server.Config.RoleMessageData.RoleMessage = roleMessage;
        }

        _server.SaveData();
    }

    private async Task AddReactions(IMessage message)
    {
        _logger.LogDebug("Start add reactions");
        
        await message.AddReactionAsync(RoleMessageEmote.One);
        await message.AddReactionAsync(RoleMessageEmote.Two);
        await message.AddReactionAsync(RoleMessageEmote.Three);
        await message.AddReactionAsync(RoleMessageEmote.Four);
        await message.AddReactionAsync(RoleMessageEmote.Five);
    }

    // await Context.Message.ReferencedMessage.ReplyAsync(Switcher.Switch(Context.Message.ReferencedMessage.Content.ToLower()));
}