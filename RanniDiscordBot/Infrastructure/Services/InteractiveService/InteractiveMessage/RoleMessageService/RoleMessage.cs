using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.
    RoleMessageService;

[Serializable]
public class RoleMessage : IInteractiveMessage
{

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
                if (TryGetRole("1 курс", chanel, out var role))
                    if (role != null)
                        SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Two):
            {
                if (TryGetRole("2 курс", chanel, out var role))
                    if (role != null)
                        SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Three):
            {
                if (TryGetRole("3 курс", chanel, out var role))
                    if (role != null)
                        SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Four):
            {
                if (TryGetRole("4 курс", chanel, out var role))
                    if (role != null)
                        SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Five):
            {
                if (TryGetRole("5 курс", chanel, out var role))
                    if (role != null)
                        SetRole(reaction.User.Value, role);
                break;
            }
        }
    }

    //TODO: fix bad code
    private bool TryGetRole(string roleName, Cacheable<IMessageChannel, ulong> chanel, out SocketRole? role)
    {
        role = (chanel.Value as SocketGuildChannel)?.Guild.Roles.FirstOrDefault(r => r.Name == roleName);

        return true;

        // if (role != null)
        //     return true;
        // else
        //     return false;
    }

    private void SetRole(IUser user, IRole role)
    {
        (user as SocketGuildUser)?.AddRoleAsync(role);
    }
}