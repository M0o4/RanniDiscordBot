using Discord;
using Discord.WebSocket;

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

    public Task Interact(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> chanel,
        SocketReaction reaction)
    {
        ReadReactionAndSetRole(chanel, reaction);
        return Task.CompletedTask;
    }

    private void ReadReactionAndSetRole(Cacheable<IMessageChannel, ulong> chanel, SocketReaction reaction)
    {
        switch (reaction.Emote)
        {
            case var _ when Equals(reaction.Emote, RoleMessageEmote.One):
            {
                var role = GetRole(FirstYear, chanel);
                if (role != null)
                    SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Two):
            {
                var role = GetRole(SecondYear, chanel);
                if (role != null)
                    SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Three):
            {
                var role = GetRole(ThirdYear, chanel);
                if (role != null)
                    SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Four):
            {
                var role = GetRole(FourthYear, chanel);
                if (role != null)
                    SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Five):
            {
                var role = GetRole(FifthYear, chanel);
                if (role != null)
                    SetRole(reaction.User.Value, role);
                break;
            }
        }
    }

    private SocketRole? GetRole(string roleName, Cacheable<IMessageChannel, ulong> chanel) =>
        (chanel.Value as SocketGuildChannel)?.Guild.Roles.FirstOrDefault(r => r.Name == roleName);

    private void SetRole(IUser user, IRole role)
    {
        (user as SocketGuildUser)?.AddRoleAsync(role);
    }
}