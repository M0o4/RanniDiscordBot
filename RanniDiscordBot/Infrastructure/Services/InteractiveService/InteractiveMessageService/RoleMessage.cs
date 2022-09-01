using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessageService;

public class RoleMessage : IInteractiveMessage
{
    public IUserMessage Message => _message;

    private IUserMessage _message;

    public string Interact(SocketReaction reaction)
    {
        return string.Empty;
    }

    public string GetRoleName(SocketReaction reaction)
    {
        switch (reaction.Emote)
        {
            case var _ when  Equals(reaction.Emote, RoleMessageEmote.One):
                return "1 курс";
            case var _ when  Equals(reaction.Emote, RoleMessageEmote.Two):
                return "2 курс";
            case var _ when  Equals(reaction.Emote, RoleMessageEmote.Three):
                return "3 курс";
            case var _ when  Equals(reaction.Emote, RoleMessageEmote.Four):
                return "4 курс";
            case var _ when  Equals(reaction.Emote, RoleMessageEmote.Five):
                return "5 курс";
            default:
                return "";
        }
    }

    public void ReadReactionAndSetRole(SocketReaction reaction, SocketUser user)
    {
        switch (reaction.Emote)
        {
            case var _ when Equals(reaction.Emote, RoleMessageEmote.One):
                //SetRole(user, );
            break;
                
        }
    }
    
    private void SetRole(SocketUser user, SocketRole role)
    {
        (user as IGuildUser)?.AddRoleAsync(role);
    }
}