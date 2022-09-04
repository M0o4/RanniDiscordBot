using Discord;
using Discord.WebSocket;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.RoleMessageService.
    Utils;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.
    RoleMessageService;

[Serializable]
public class RoleMessage : IInteractiveMessage
{
    private const string FirstYear = "1 курс";
    private const string SecondYear = "2 курс";
    private const string ThirdYear = "3 курс";
    private const string FourthYear = "4 курс";
    private const string FifthYear = "5 курс";

    private AddRoleUtil _addRoleUtil;
    private RemoveRoleUtil _removeRoleUtil;

    public RoleMessage()
    {
        _addRoleUtil = new AddRoleUtil();
        _removeRoleUtil = new RemoveRoleUtil();
    }

    public Task OnReactionAddedAsync(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> chanel,
        SocketReaction reaction)
    {
        ReadReactionAndHandleRole(chanel, reaction, _addRoleUtil);
        return Task.CompletedTask;
    }

    public Task OnReactionRemovedAsync(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> chanel,
        SocketReaction reaction)
    {
        ReadReactionAndHandleRole(chanel, reaction, _removeRoleUtil);
        return Task.CompletedTask;
    }

    private void ReadReactionAndHandleRole(Cacheable<IMessageChannel, ulong> chanel, SocketReaction reaction,
        RoleUtil roleUtil)
    {
        switch (reaction.Emote)
        {
            case var _ when Equals(reaction.Emote, RoleMessageEmote.One):
            {
                roleUtil.HandleRole(FirstYear, chanel, reaction);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Two):
            {
                roleUtil.HandleRole(SecondYear, chanel, reaction);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Three):
            {
                roleUtil.HandleRole(ThirdYear, chanel, reaction);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Four):
            {
                roleUtil.HandleRole(FourthYear, chanel, reaction);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Five):
            {
                roleUtil.HandleRole(FifthYear, chanel, reaction);
                break;
            }
        }
    }
}