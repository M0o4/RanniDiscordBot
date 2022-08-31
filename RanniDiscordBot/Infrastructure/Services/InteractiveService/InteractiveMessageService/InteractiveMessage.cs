using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessageService;

public class InteractiveMessage
{
    public IUserMessage Message => _message;
    
    private IUserMessage _message;

    public void ReadReactionAndSetRole(SocketReaction reaction, SocketUser user)
    {
        switch (reaction.Emote)
        {
            case var _ when Equals(reaction.Emote, InteractiveMessageEmote.One):
                //SetRole(user, );
            break;
                
        }
    }
    
    private void SetRole(SocketUser user, SocketRole role)
    {
        (user as IGuildUser)?.AddRoleAsync(role);
    }
}