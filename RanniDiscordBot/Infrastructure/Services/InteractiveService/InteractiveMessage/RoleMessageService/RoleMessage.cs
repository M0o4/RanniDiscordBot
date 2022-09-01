using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.
    RoleMessageService;

[Serializable]
public class RoleMessage : IInteractiveMessage
{
    public Task Interact(SocketReaction reaction)
    {
        ReadReactionAndSetRole(reaction);
        return Task.CompletedTask;
    }

    private void ReadReactionAndSetRole(SocketReaction reaction)
    {
        switch (reaction.Emote)
        {
            case var _ when Equals(reaction.Emote, RoleMessageEmote.One):
            {
                if (TryGetRole("1 курс", out var role))
                    SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Two):
            {
                if (TryGetRole("2 курс", out var role))
                    SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Three):
            {
                if (TryGetRole("3 курс", out var role))
                    SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Four):
            {
                if (TryGetRole("4 курс", out var role))
                    SetRole(reaction.User.Value, role);
                break;
            }
            case var _ when Equals(reaction.Emote, RoleMessageEmote.Five):
            {
                if (TryGetRole("5 курс", out var role))
                    SetRole(reaction.User.Value, role);
                break;
            }
        }
    }

    private bool TryGetRole(string roleName, out SocketRole role)
    {
        role = Roles.ServerRoles.FirstOrDefault(r => r.Name == roleName);

        if (role != null)
            return true;
        else
            return false;
    }

    private void SetRole(IUser user, SocketRole role)
    {
        (user as IGuildUser)?.AddRoleAsync(role);
    }
}